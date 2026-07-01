using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Web.WebView2.Core;

namespace NexusPobreFlix
{
    public partial class MainWindow : Window
    {
        private readonly string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
        private readonly string profilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "perfil-pobreflix");
        private string savedServerUrl = string.Empty;
        private bool isFullscreen = true;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(configFilePath))
            {
                try
                {
                    string saved = File.ReadAllText(configFilePath).Trim();
                    if (!string.IsNullOrEmpty(saved))
                    {
                        savedServerUrl = saved;
                        configGrid.Visibility = Visibility.Collapsed;
                        webView.Visibility = Visibility.Visible;
                        await InitializeBrowserAsync(savedServerUrl);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao ler configuração: " + ex.Message, "Nexus PobreFlix", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Se não encontrou config, exibe o painel de input e foca a caixa de texto
            txtServerUrl.Focus();
        }

        private async Task InitializeBrowserAsync(string serverUrl)
        {
            try
            {
                // Limpar a URL para pegar apenas a origem (protocolo + host + porta) para o flag do Chromium
                string cleanOrigin = GetOriginFromUrl(serverUrl);

                // Configurar argumentos do Chromium: tratar a origem insegura local como segura (habilita Gamepad API)
                // e desativar requisitos de gesto do usuário para autoplay de trailers
                string browserArgs = $"--unsafely-treat-insecure-origin-as-secure=\"{cleanOrigin}\" --autoplay-policy=no-user-gesture-required --no-first-run --no-default-browser-check";
                
                var options = new CoreWebView2EnvironmentOptions(additionalBrowserArguments: browserArgs);
                
                // Inicializar com perfil de navegador persistente na pasta do app
                var environment = await CoreWebView2Environment.CreateAsync(
                    browserExecutableFolder: null,
                    userDataFolder: profilePath,
                    options: options
                );

                await webView.EnsureCoreWebView2Async(environment);

                // Forçar foco no controle WebView2 ao terminar de carregar a página
                webView.NavigationCompleted += (s, args) =>
                {
                    webView.Focus();
                };

                // Ouvir mensagens enviadas do JavaScript (como o comando de fechar o app pelo controle)
                webView.WebMessageReceived += (s, args) =>
                {
                    if (args.TryGetWebMessageAsString() == "exit_app")
                    {
                        Application.Current.Shutdown();
                    }
                };

                // Ajustar comportamento de atalhos e menus contextuais do WebView2
                webView.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
                webView.CoreWebView2.Settings.AreDevToolsEnabled = true;
                webView.CoreWebView2.Settings.IsZoomControlEnabled = false;

                // Definir rota inicial forçando layout de TV e idioma PT-BR
                string targetUrl = serverUrl;
                if (!targetUrl.Contains("web/index.html"))
                {
                    if (targetUrl.EndsWith("/"))
                    {
                        targetUrl += "web/index.html";
                    }
                    else
                    {
                        targetUrl += "/web/index.html";
                    }
                }

                // Append TV layout query parameter
                if (!targetUrl.Contains("layout=tv"))
                {
                    targetUrl += targetUrl.Contains("?") ? "&layout=tv" : "?layout=tv";
                }

                webView.Source = new Uri(targetUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao inicializar o Chromium: " + ex.Message + "\nCertifique-se de que o Microsoft Edge WebView2 está instalado.", "Erro do Sistema", MessageBoxButton.OK, MessageBoxImage.Error);
                configGrid.Visibility = Visibility.Visible;
                webView.Visibility = Visibility.Collapsed;
            }
        }

        private string GetOriginFromUrl(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                return uri.GetLeftPart(UriPartial.Authority);
            }
            catch
            {
                return url;
            }
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            await ProcessConnectionAsync();
        }

        private async Task ProcessConnectionAsync()
        {
            string input = txtServerUrl.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Por favor, digite o endereço do servidor Jellyfin.", "Nexus PobreFlix", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Adicionar http:// automaticamente se não possuir protocolo
            if (!input.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && 
                !input.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                input = "http://" + input;
            }

            // Validar formato de URL básica
            try
            {
                var uri = new Uri(input);
            }
            catch
            {
                MessageBox.Show("Endereço de servidor inválido. Verifique o formato digitado.", "Nexus PobreFlix", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                File.WriteAllText(configFilePath, input);
                savedServerUrl = input;
                configGrid.Visibility = Visibility.Collapsed;
                webView.Visibility = Visibility.Visible;
                await InitializeBrowserAsync(savedServerUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar as configurações: " + ex.Message, "Erro de Configuração", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Atalho F11 - Alternar Tela Cheia
            if (e.Key == Key.F11)
            {
                ToggleFullscreen();
                e.Handled = true;
            }
            // Atalho F5 - Atualizar Página (somente se carregado)
            else if (e.Key == Key.F5)
            {
                if (webView.Visibility == Visibility.Visible && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Reload();
                    e.Handled = true;
                }
            }
            // Atalho Ctrl+Shift+I - Abrir DevTools do Chromium (Debugging)
            else if (e.Key == Key.I && (Keyboard.Modifiers & (ModifierKeys.Control | ModifierKeys.Shift)) == (ModifierKeys.Control | ModifierKeys.Shift))
            {
                if (webView.Visibility == Visibility.Visible && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.OpenDevToolsWindow();
                    e.Handled = true;
                }
            }
            // Atalho Ctrl+W ou Alt+F4 - Sair do Programa
            else if ((e.Key == Key.W && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) ||
                     (e.Key == Key.System && e.SystemKey == Key.F4))
            {
                Application.Current.Shutdown();
                e.Handled = true;
            }
        }

        private void ToggleFullscreen()
        {
            if (isFullscreen)
            {
                // Entrar em modo janela normal com barra superior
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                this.ResizeMode = ResizeMode.CanResize;
                this.Height = 720;
                this.Width = 1280;
                isFullscreen = false;
            }
            else
            {
                // Entrar em modo tela cheia Kiosk
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                this.ResizeMode = ResizeMode.NoResize;
                isFullscreen = true;
            }
        }

        // --- Gerenciamento Visual da Caixa de Texto ---
        private void TxtServerUrl_GotFocus(object sender, RoutedEventArgs e)
        {
            lblPlaceholder.Visibility = Visibility.Collapsed;
        }

        private void TxtServerUrl_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtServerUrl.Text))
            {
                lblPlaceholder.Visibility = Visibility.Visible;
            }
        }

        private async void TxtServerUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                await ProcessConnectionAsync();
            }
        }
    }
}
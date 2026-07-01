# 📺 Nexus Jellyfin Desktop — Premium TV Player

> [!NOTE]  
> **Português:** A tradução em português deste documento encontra-se na segunda metade deste arquivo.  
> **English:** The English documentation is shown first, followed by the Portuguese version at the end.

---

![Nexus Jellyfin Desktop Logo](logo%20nexus%20desktop.png)

**Nexus Jellyfin Desktop** is a custom client built specifically for Windows PCs. It is designed to work in perfect harmony with the [Nexus PobreFlix Jellyfin plugin](https://github.com/ONeithan/Nexus-PobreFlix).

### 🎮 Why was this Fork created?
This project is a dedicated **fork** of the official **Jellyfin Media Player / Jellyfin Desktop** project. 

The primary reason this fork was developed is to deliver a seamless TV experience for PC users:
* **Native Steam Integration**: Fully compatible with the **Steam Overlay** in Big Picture mode.
* **Controller Support**: Designed to hook and map Xbox, PlayStation, or Steam Deck controllers natively inside the Jellyfin TV UI without any complex configuration or key-mappers.
* **PobreFlix Optimization**: Tailored to load and render the custom visual overrides, styling layers, and layouts provided by the PobreFlix plugin server.

Instead of CEF (Chromium Embedded Framework) wrappers, this client is rebuilt as a native C# WPF application utilizing the **Microsoft WebView2 (Chromium Engine)**. This yields an executable size of **only 1 MB** (accompanied by runtime libraries), fast boot times, and native hardware acceleration.

---

## ✨ Features:

* **🎮 Native Gamepad Support (Gamepad API)**: Automatically connects and maps controllers directly inside the Jellyfin TV interface.
* **📺 Kiosk Mode (True Fullscreen)**: Launches in borderless fullscreen, hiding the title bar, windows close buttons, and the Windows taskbar for a clean console-like TV UI.
* **🔒 Persistent Session Login**: All settings, local storage, passwords, and sessions are stored inside the `perfil-pobreflix` folder, requiring you to enter your credentials only once.
* **🛡️ Secure Context Bypass (HTTP)**: Automatically enables the Gamepad API over insecure HTTP local addresses by passing the `--unsafely-treat-insecure-origin-as-secure` flag under the hood.
* **🎹 Keyboard & Gamepad Shortcuts**:
  - **Xbox Guide / Home Button** (or **Select + Start**): Closes the application instantly (returning you to Steam Big Picture).
  - **F11**: Toggles between Kiosk Fullscreen and normal windowed mode.
  - **F5**: Reloads the current page.
  - **Ctrl + Shift + I**: Opens Developer Tools (DevTools) for debugging.
  - **Ctrl + W** or **Alt + F4**: Exits the app.

---

## 🚀 Installation & How to Use:

1. Download the latest version of the client from the [Releases page](https://github.com/ONeithan/Nexus-jellyfin-desktop/releases).
2. Extract the contents of the downloaded ZIP folder to any directory on your computer.
3. Double-click **`NexusJellyfinDesktop.exe`** to launch the player!
*Note: Make sure to keep all the `.dll` and `.json` files in the same folder as the `.exe` so the application functions properly.*

---

## 📄 Credits & Legal Notice:

* **Original Project Base**: This client is a custom fork based on the official **Jellyfin Media Player** developed by the Jellyfin Project and contributors. All original code ownership, trademark rights, and credits belong to the Jellyfin team.
* **Modifications & Maintenance**: Re-authored, simplified, and maintained in C# WPF by [ONeithan](https://github.com/ONeithan) specifically for the Nexus PobreFlix ecosystem.
* **Licensing**: Licensed under the open-source MIT License.

---
---

# 📺 Nexus Jellyfin Desktop — Player de TV Premium

O **Nexus Jellyfin Desktop** é um cliente customizado desenvolvido especificamente para computadores Windows. Ele foi projetado para rodar em perfeita harmonia com o [plugin Jellyfin Nexus PobreFlix](https://github.com/ONeithan/Nexus-PobreFlix).

### 🎮 Por que este Fork foi criado?
Este projeto é um **fork** dedicado baseado no projeto oficial **Jellyfin Media Player / Jellyfin Desktop**. 

O motivo principal para a criação deste fork é fornecer uma experiência de TV livre de dores de cabeça para usuários de computador:
* **Integração Nativa com a Steam**: Totalmente compatível com o **Steam Overlay** no modo Big Picture.
* **Suporte Completo a Controles**: Mapeia automaticamente controles de Xbox, PlayStation ou Steam Deck diretamente na interface do Jellyfin TV, sem precisar de emuladores de teclado ou mapeadores de terceiros.
* **Otimização PobreFlix**: Ajustado especificamente para renderizar as correções de CSS, os painéis visuais roxos e a navegação trazida pelo plugin PobreFlix do servidor.

Em vez de empacotadores CEF pesados, este cliente foi reescrito como uma aplicação WPF em C# nativa do Windows utilizando a API do **Microsoft WebView2 (Chromium)**. Isso resulta em um tamanho de executável de **apenas 1 MB** (acompanhado por bibliotecas auxiliares de carregamento), inicialização instantânea e aceleração por hardware nativa.

---

## ✨ Recursos:

* **🎮 Suporte Nativo a Controles (Gamepad API)**: Lê e mapeia automaticamente os controles diretamente na interface do Jellyfin TV.
* **📺 Modo Kiosk (Tela Cheia Exclusiva)**: Inicia em tela cheia sem bordas, ocultando a barra de título, botões de fechar e a barra de tarefas do Windows.
* **🔒 Persistência de Sessão**: Cookies, senhas e preferências permanecem salvos permanentemente no diretório `perfil-pobreflix`, exigindo que você digite a senha apenas uma única vez.
* **🛡️ Liberação de Contexto Seguro (HTTP)**: Ativa a Gamepad API mesmo em conexões locais sem certificado SSL de forma automática.
* **🎹 Atalhos Rápidos**:
  - **Botão Xbox Guide / Home** (ou **Select + Start**): Fecha o aplicativo imediatamente (retornando você para o Big Picture da Steam).
  - **F11**: Alterna entre tela cheia exclusiva e janela redimensionável.
  - **F5**: Atualiza a página.
  - **Ctrl + Shift + I**: Abre as ferramentas de desenvolvedor (DevTools) para depuração.
  - **Ctrl + W** ou **Alt + F4**: Fecha o aplicativo.

---

## 🚀 Instalação & Como Usar:

1. Baixe a versão mais recente do cliente diretamente na [página de Releases](https://github.com/ONeithan/Nexus-jellyfin-desktop/releases).
2. Extraia o conteúdo completo do arquivo ZIP em qualquer diretório de sua escolha no seu computador.
3. Dê dois cliques no executável **`NexusJellyfinDesktop.exe`** para iniciar o player!
*Nota: É fundamental manter todas as DLLs e arquivos .json na mesma pasta que o executável para que o programa funcione de maneira correta.*

---

## 📄 Créditos & Nota Legal:

* **Projeto Base Original**: Este cliente é um fork customizado baseado no **Jellyfin Media Player** oficial, desenvolvido pelo Jellyfin Project e seus colaboradores. Todos os direitos e créditos da marca e da base original pertencem à equipe do Jellyfin.
* **Modificações e Manutenção**: Simplificado, reescrito em WPF e mantido por [ONeithan](https://github.com/ONeithan) especificamente para o ecossistema Nexus PobreFlix.
* **Licenciamento**: Licenciado sob a Licença de código aberto MIT.

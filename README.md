# 📺 Nexus PobreFlix Desktop — Premium TV Player (v1.0.0.0)

> [!NOTE]  
> **Português:** A tradução em português deste documento encontra-se na segunda metade deste arquivo.  
> **English:** The English documentation is shown first, followed by the Portuguese version at the end.

---

![Nexus PobreFlix Desktop Logo](logo%20nexus%20desktop.png)

**Nexus PobreFlix Desktop** is a custom client built specifically for Windows PCs to run in perfect harmony with the [Nexus PobreFlix Jellyfin plugin](https://github.com/ONeithan/Nexus-PobreFlix).

Instead of the standard bulky web wrappers, this client is built as a native C# WPF application utilizing the **Microsoft WebView2 (Chromium Engine)**. This yields an executable size of **only 1 MB**, extremely fast boot times, native hardware acceleration, and full compatibility with the **Steam Overlay** in Big Picture mode.

---

## ✨ Features:

* **🎮 Native Gamepad Support (Gamepad API)**: Automatically connects and maps Xbox, PlayStation, or Steam Deck controllers directly inside the Jellyfin TV user interface without the need for key-simulation software.
* **📺 Kiosk Mode (True Fullscreen)**: Launches in borderless fullscreen, hiding the title bar, windows close buttons, and the Windows taskbar for a clean console-like TV UI.
* **🔒 Persistent Session Login**: All settings, local storage, passwords, and sessions are encrypted and stored inside the `perfil-pobreflix` folder, requiring you to enter your credentials only once.
* **🛡️ Secure Context Bypass (HTTP)**: Automatically enables the HTML5 Gamepad API and secure APIs over insecure HTTP local addresses by passing the `--unsafely-treat-insecure-origin-as-secure` flag under the hood.
* **🎹 Keyboard & Gamepad Shortcuts**:
  - **Xbox Guide / Home Button** (or **Select + Start**): Closes the application instantly (returning you to Steam Big Picture).
  - **F11**: Toggles between Kiosk Fullscreen and normal windowed mode.
  - **F5**: Reloads the current page.
  - **Ctrl + Shift + I**: Opens Developer Tools (DevTools) for debugging.
  - **Ctrl + W** or **Alt + F4**: Exits the app.

---

## 🚀 Installation & How to Use:

1. Go to the **Releases** tab on GitHub and download **`NexusJellyfinDesktop-1.0.0.0.zip`**.
2. Extract the contents of the ZIP folder to any directory of your choice.
3. Double-click **`NexusJellyfinDesktop.exe`** to launch the player!
*Note: Make sure to keep all the `.dll` and `.json` files in the same folder as the `.exe` so the application functions properly.*

---

## 📄 Credits:

* **Development & Customization**: [ONeithan](https://github.com/ONeithan)
* **Concept & Base**: Rewritten from scratch in C# WPF to bypass CEF dependencies and deliver a highly optimized desktop client for the Nexus PobreFlix ecosystem.

---
---

# 📺 Nexus PobreFlix Desktop — Player de TV Premium (v1.0.0.0)

O **Nexus PobreFlix Desktop** é um cliente customizado desenvolvido especificamente para computadores Windows para rodar em perfeita harmonia com o [plugin Jellyfin Nexus PobreFlix](https://github.com/ONeithan/Nexus-PobreFlix).

Em vez do reprodutor padrão pesado, este cliente foi reescrito como uma aplicação WPF em C# nativa do Windows utilizando a API do **Microsoft WebView2 (Chromium)**. Isso resulta em um executável de **apenas 1 MB**, inicialização instantânea, aceleração por hardware nativa e compatibilidade total com o **Steam Overlay** no modo Big Picture.

---

## ✨ Recursos:

* **🎮 Suporte Nativo a Controles (Gamepad API)**: Lê e mapeia automaticamente os controles de Xbox, PlayStation ou Steam Deck diretamente na interface do Jellyfin TV, sem precisar de emuladores de teclado.
* **📺 Modo Kiosk (Tela Cheia Exclusiva)**: Inicia em tela cheia sem bordas, ocultando a barra de título, botões de fechar e a barra de tarefas do Windows para uma experiência pura de console.
* **🔒 Persistência de Sessão**: Cookies, senhas e preferências permanecem salvos permanentemente no diretório `perfil-pobreflix`, exigindo que você digite a senha apenas uma única vez.
* **🛡️ Liberação de Contexto Seguro (HTTP)**: Injeta parâmetros no Chromium para tratar a origem HTTP local como segura (`--unsafely-treat-insecure-origin-as-secure`), ativando a Gamepad API mesmo em conexões locais sem certificado SSL.
* **🎹 Atalhos Rápidos**:
  - **Botão Xbox Guide / Home** (ou **Select + Start**): Fecha o aplicativo imediatamente (retornando você para o Big Picture da Steam).
  - **F11**: Alterna entre tela cheia exclusiva e janela redimensionável.
  - **F5**: Atualiza a página.
  - **Ctrl + Shift + I**: Abre as ferramentas de desenvolvedor (DevTools) para depuração.
  - **Ctrl + W** ou **Alt + F4**: Fecha o aplicativo.

---

## 🚀 Instalação & Como Usar:

1. Acesse a aba de **Releases** do repositório no GitHub e baixe o arquivo **`NexusJellyfinDesktop-1.0.0.0.zip`**.
2. Extraia o conteúdo completo da pasta ZIP em qualquer diretório de sua escolha no seu computador.
3. Dê dois cliques no executável **`NexusJellyfinDesktop.exe`** para iniciar o player!
*Nota: É fundamental manter todas as DLLs e arquivos .json na mesma pasta que o executável para que o programa funcione de maneira correta.*

---

## 📄 Créditos:

* **Desenvolvimento e Customização**: [ONeithan](https://github.com/ONeithan)
* **Base do Projeto**: Reescrito do zero em C# WPF para contornar dependências do CEF e entregar um cliente altamente otimizado para o ecossistema Nexus PobreFlix.

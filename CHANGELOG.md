# 📜 Registro de Alterações — Nexus PobreFlix Desktop (CHANGELOG)

Este arquivo documenta todas as atualizações, novos recursos, melhorias e correções feitas no cliente desktop oficial do **Nexus PobreFlix**.

---

## 🚀 Versão v1.0.0.0 (Lançamento Inicial Oficial) — 01/07/2026

Esta é a primeira versão estável do cliente desktop oficial do **Nexus PobreFlix**, desenvolvido sob medida por **ONeithan** para PCs Windows e setups de TV/HTPC (totalmente integrado com o Big Picture da Steam).

### 🛠️ O que há de novo nesta versão:

#### 1. 🖥️ Redesenho Completo de Arquitetura (Rust CEF ➔ C# WPF WebView2)
* **Redução Drástica de Tamanho**: Abandonamos a base pesada em Rust e CEF (que gerava builds de 150MB) em prol de uma solução nativa em C# WPF utilizando o **Microsoft WebView2 (motor Chromium do Edge)**. O tamanho final do executável foi reduzido para **apenas 1 MB**!
* **Aceleração Gráfica por Hardware**: Boot ultra-rápido e renderização suave a 60 FPS, garantindo zero lag na interface e compatibilidade imediata com o Steam Overlay.
* **Consumo de Memória Reduzido**: Gerenciamento de memória otimizado através de processos compartilhados do sistema operacional.

#### 2. 🎮 Suporte Nativo a Controles (Gamepad API) e Bypass HTTP
* **Bypass de Contexto Seguro (HTTP)**: Navegadores modernos bloqueiam o uso de gamepads em conexões HTTP. Implementamos uma injeção de flags no Chromium (`--unsafely-treat-insecure-origin-as-secure`) para tratar o endereço local do seu servidor Jellyfin como seguro.
* **Mapeamento de Botões**: Controles de Xbox 360, Xbox One, Xbox Series X/S, PlayStation 4/5 e Steam Deck são detectados e mapeados nativamente, permitindo controlar toda a interface como em um console!

#### 3. 🎯 Correções Críticas de Usabilidade e Foco
* **Foco Automático de Inicialização (Mouse Free)**: Corrigido o bug que exigia que o usuário clicasse com o mouse no aplicativo para ativar o controle. O aplicativo agora força o foco programático no WebView2 no startup e ao concluir qualquer navegação.
* **Funcionamento Universal do Controle**: O controle agora simula eventos de teclado reais no modo TV e Desktop, permitindo navegar facilmente por todas as seções (como as listas "Top 10" e menus suspensos) e rolar a página normalmente.
* **Efeito de Foco Premium e Arredondado**: Removemos o contorno padrão (`outline`) quadrado que ficava torto nos cards e episódios. Agora, os elementos selecionados recebem uma **borda roxa brilhante com neon (`box-shadow`)** que acompanha o arredondamento original de cada card de forma suave e harmônica.

#### 4. ↩️ Funcionamento Inteligente do Botão B (Voltar)
* **Voltar Inteligente**: Mapeamos o botão B do controle para buscar e clicar nos botões físicos de fechar modais, fechar trailers e fechar painéis de detalhes (como na tela "Na Rota do Crime"). 
* **Retorno de Histórico**: Caso nenhum botão de fechar esteja visível, ele simula a tecla `Escape` e aciona o histórico de páginas do navegador (`history.back()`) para voltar sem quebras.

#### 5. 🚪 Atalhos de Controle para Fechamento Rápido
* **Botão Home/Guide do Xbox**: Apertar o botão central do controle fecha o aplicativo na hora.
* **Atalho Combo (Select + Start)**: Segurar os dois botões de opções do controle fecha o aplicativo instantaneamente, perfeito para retornar à Steam no modo Big Picture sem precisar de mouse ou teclado.

#### 6. 🔒 Persistência de Sessão e Configuração Inteligente
* **Login Único e Permanente**: Criamos a pasta isolada `perfil-pobreflix` na raiz do executável. Todos os cookies de login, dados do usuário e senhas ficam gravados nela de forma isolada e segura. Você só precisa digitar sua senha na primeira vez!
* **Configuração Simplificada do Servidor**: Se o arquivo `config.txt` estiver ausente, o programa exibe uma tela roxa premium nativa solicitando a URL do seu servidor Jellyfin e a salva automaticamente.

---

### 📦 Detalhes do Build:

* **Arquivo**: `NexusPobreFlixDesktop-1.0.0.0.zip`
* **Localização**: `dist's/NexusPobreFlixDesktop-1.0.0.0.zip`
* **Versão**: `1.0.0.0`
* **Status**: Estável e Pronta para Produção
* **Desenvolvedor**: [ONeithan](https://github.com/ONeithan)

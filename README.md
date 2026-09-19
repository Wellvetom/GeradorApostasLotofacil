# 🎯 Gerador de Apostas Lotofácil

Aplicação desktop desenvolvida em **C# com Windows Forms (.NET 10)** para gerar, criar, conferir, verificar e acompanhar apostas da Lotofácil com inteligência baseada no histórico de resultados oficiais.

![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-blue)
![EF Core](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-green)
![SQL Server](https://img.shields.io/badge/DB-SQL%20Server-red)

---

## 🚀 Funcionalidades

### 🔐 Autenticação e Perfis
- **Login e Cadastro** de usuários.
- **Senhas com hash BCrypt**, com migração automática de hashes legados (SHA256) para BCrypt no primeiro login.
- **Perfis de acesso**: `Usuario`, `Administrador` e `Admin`, com visibilidade do menu condicionada ao perfil.
- **Logoff** e controle de sessão do usuário logado.

### 🎲 Geração Inteligente de Apostas
- Gera **múltiplos jogos** de uma vez, definindo a quantidade desejada.
- Algoritmo configurável por faixas:
  - quantidade de números **mais sorteados** (top do ranking histórico);
  - quantidade de números **menos sorteados**;
  - o restante é completado com números **aleatórios** (indicador ao vivo de quantos serão aleatórios).
- **Garantia de ineditismo**: cada jogo gerado é checado contra a base para não repetir jogos já existentes.
- **Gravação com verificação de duplicidade**: antes de salvar, o sistema avisa se já existe uma aposta idêntica para o mesmo sorteio e pede confirmação.
- Grade visual com os 15 números de cada jogo gerado.

### ✍️ Criação Manual de Apostas
Acessível pelo botão **"Criar manualmente"** dentro da tela de Incluir Apostas:
- **Seleção por toggles** dos números de 1 a 25 (mesmo padrão da tela de Verificar Aposta), limitada a 15 números, com contador em tempo real.
- **🔎 Verificar**: mostra, para o jogo montado:
  - se você já apostou exatamente esses números;
  - se o jogo **já foi sorteado** oficialmente com **12, 13, 14 ou 15 acertos** (contagem por faixa);
  - o **melhor resultado histórico** (acertos × números não sorteados, com concurso e data);
  - uma grade com todos os sorteios oficiais em que o jogo bateu 12+ acertos.
- **💾 Gravar**: salva a aposta criada manualmente, associando a data do próximo sorteio (via RPA) e verificando duplicidade.
- **🎲 Gerar auto (por critério)**: gera **um único jogo inédito** que atenda a um critério informado pelo usuário:
  - escolha do **alvo de acertos** por sorteio (**11, 12, 13 ou 14**);
  - **quantidade mínima de sorteios já ocorridos** que devem atingir esse alvo.
  - O jogo resultante é **inédito na base** e preenche automaticamente os toggles, pronto para verificar ou gravar.
- **🧹 Limpar**: reinicia a seleção e os resultados.

### 🔎 Verificação de Apostas (tela dedicada)
- Seleção de 15 números (1 a 25) por toggles.
- Indica se **você já apostou** esses números.
- Indica se **já foi sorteado** oficialmente com 12/13/14/15 acertos.
- Mostra o **melhor resultado histórico** e uma grade com os sorteios de 12+ acertos (faixa, concurso, data e números acertados).

### 📋 Listagem de Apostas
- Visualização das apostas do usuário com a **quantidade de acertos por jogo** (conferência automática contra os resultados oficiais).
- **Exportação CSV** das apostas.
- Exclusão lógica de apostas (soft delete via data de exclusão).

### 📊 Dashboard Pessoal
- **Cards de métricas**: total de apostas, total de jogos, melhor acerto, última aposta, taxa de 11+ acertos e número da sorte.
- **Gráfico de distribuição de acertos** (11 a 15) com custom painting (GDI+).
- **Gráfico de jogos por dia**.
- **Top 10 números mais usados** e **Top 10 números de aderência** (sugestão para o próximo jogo, com base em jogos conferidos e não premiados) em gráficos de pizza.
- **Verificar meu jogo**: selecione um dos seus jogos já criados e veja se ele **já foi sorteado** com 12/13/14/15 acertos, com resumo e grade dos sorteios correspondentes.

### ⬇️ Importação de Resultados (Administrador / Admin)
- Busca automática de sorteios oficiais da Lotofácil via **RPA (LoteriasCaixaRobot.dll)**.
- Importação dos resultados para a base, servindo de referência para conferência e geração.

### 🛡️ Painel Administrativo (Administrador / Admin)
- **Estatísticas dos sorteios importados**:
  - total de sorteios importados;
  - números mais e menos sorteados (top 15);
  - últimos 10 sorteios oficiais;
  - detecção de jogos repetidos entre os resultados importados.

### 🔄 Navegação
- **Navegação SPA-like**: as telas são trocadas dentro de um painel único, sem abrir múltiplas janelas.
- **Janela borderless** com barra de título customizada e controles de janela.

---

## 🧱 Arquitetura

```
📦 GeradorApostasLotofacil
 ┣ 📂 Domain              → Entidades (ApostaModel, JogoModel, UsuarioModel)
 ┣ 📂 Application         → Serviços e interfaces de negócio
 ┃   ┣ ApostaService         (gravar, listar, excluir, verificar duplicidade)
 ┃   ┣ GeracaoService        (geração inteligente + geração por critério de acertos)
 ┃   ┣ ImportacaoService     (importação de resultados via RPA)
 ┃   ┣ ConferenciaService    (conferência de acertos e verificação de jogos)
 ┃   ┣ DashboardService      (dashboard do usuário)
 ┃   ┣ AdminDashboardService (dashboard administrativo)
 ┃   ┣ UsuarioService        (autenticação, cadastro)
 ┃   ┗ NavigationService     (navegação entre forms)
 ┣ 📂 Repository           → Acesso a dados (IApostaRepository, IUsuarioRepository)
 ┣ 📂 Infrastructure       → DbContext + configuração EF Core
 ┣ 📂 DTO                  → ViewModels de transferência
 ┣ 📂 Helper               → Utilitários (JogoHelper, ApostaGridViewModel)
 ┣ 📂 Controls             → Controles customizados (PieChartControl)
 ┣ 📂 Session              → Sessão do usuário logado
 ┣ 📂 Migrations           → Migrations do EF Core (Code First)
 ┣ 📂 Dll                  → LoteriasCaixaRobot.dll (RPA)
 ┗ 📄 Forms                → Login, Cadastro, GerarApostas, ApostaManual,
                             ListarApostas, VerificarAposta, ImportarApostas,
                             Dashboard, DashboardAdmin, MenuPrincipal
```

---

## 🧠 Conceitos e Padrões

| Padrão | Aplicação |
|--------|-----------|
| Clean Architecture | Separação em Domain, Application, Infrastructure |
| Dependency Injection | `Microsoft.Extensions.DependencyInjection` centralizado no `Program.cs` |
| Repository Pattern | Interfaces `IApostaRepository`, `IUsuarioRepository` |
| Service Layer | Serviços separados por responsabilidade |
| SOLID | Interfaces para cada serviço, single responsibility |
| Code First + Migrations | EF Core com evolução incremental do banco |
| Value Conversion | `List<int>` serializado como JSON no SQL Server |
| Secure Password Hashing | BCrypt com migração automática de hashes legados (SHA256) |

---

## 🗄️ Banco de Dados

- **SQL Server** com Entity Framework Core 10.
- **Code First** — schema gerenciado por migrations.
- Números dos jogos armazenados como **coluna JSON** (`nvarchar(max)` com value conversion).

### Configuração

A connection string fica em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=BD_GeradorDeApostas;Trusted_Connection=True;TrustServerCertificate=True"
  }
}
```

### Criar/Atualizar banco

```bash
dotnet ef database update
```

---

## ⚙️ Tecnologias

| Tecnologia | Versão | Uso |
|------------|--------|-----|
| .NET | 10.0 | Runtime |
| Windows Forms | — | Interface gráfica |
| Entity Framework Core | 10.0.6 | ORM + Migrations |
| SQL Server | — | Banco de dados |
| BCrypt.Net-Next | 4.0.3 | Hash de senhas |
| Microsoft.Extensions.DependencyInjection | 10.0.6 | IoC Container |
| Microsoft.Extensions.Configuration.Json | 10.0.6 | Leitura de config |
| LoteriasCaixaRobot.dll | — | RPA para busca de resultados oficiais |
| System.Text.Json | — | Serialização de dados |

---

## 🖥️ Interface

Tema escuro moderno construído com WinForms puro:

- **Paleta**: fundos em tons de (30,30,46) a (55,65,82), texto branco, acentos em azul/verde/laranja/roxo.
- **Menu lateral** com ícones emoji e visibilidade condicional por perfil.
- **DataGridView** estilizados com `AutoSizeColumnsMode.Fill`, linhas altas e seleção por linha.
- **Gráficos** com custom painting (GDI+) para distribuição de acertos e jogos por dia, e `PieChartControl` para os rankings de números.
- **Cards** com métricas em destaque (fontes grandes, cores por categoria).
- **Toggles de números** (1 a 25) para seleção manual de jogos.
- **Painel de carregamento** (`LoadingPanel`) durante operações assíncronas.
- **Janela borderless** com barra de título customizada.

---

## 🔐 Segurança

- Senhas hasheadas com **BCrypt** (work factor padrão).
- Migração automática: hash legado (SHA256) detectado no login é atualizado para BCrypt de forma transparente.
- Connection string em arquivo externo (`appsettings.json`), fora do código-fonte.
- Perfis de acesso controlam a visibilidade das funcionalidades na UI.

---

## 📋 Pré-requisitos

- Windows 10/11
- .NET 10 SDK
- SQL Server (Express, LocalDB ou instância completa)
- Visual Studio 2022+ (recomendado) ou CLI

---

## ▶️ Como Executar

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/GeradorApostasLotofacil.git
cd GeradorApostasLotofacil
```

2. Configure a connection string em `GeradorApostasLotofacil/appsettings.json`.

3. Aplique as migrations:
```bash
cd GeradorApostasLotofacil
dotnet ef database update
```

4. Execute:
```bash
dotnet run
```

---

## 👥 Perfis de Acesso

| Perfil | Acesso |
|--------|--------|
| **Usuario** | Gerar apostas, criar manualmente (com geração por critério), verificar, listar, dashboard pessoal, exportar CSV |
| **Administrador** | Tudo do Usuario + Importar resultados + Painel Admin |
| **Admin** | Mesmo que Administrador |

---

## 🧪 Possíveis Melhorias

- 📈 Gráfico de evolução de acertos ao longo do tempo.
- 🎯 Notificação automática ao atingir 11+ acertos.
- 🌐 Integração REST API para resultados (substituir a DLL de RPA).
- 🔍 Filtros avançados (por data, concurso, faixa de acertos).
- 🧪 Testes unitários com xUnit + Moq.
- 📱 Versão MAUI para cross-platform.

---

## ⚠️ Observações

- Projeto com fins **educacionais** e de prática de arquitetura.
- Não garante qualquer vantagem estatística em jogos de loteria.
- A DLL `LoteriasCaixaRobot.dll` realiza web scraping do site da Caixa — use com responsabilidade.

---

## 👨‍💻 Autor

Desenvolvido por **Wellington Almeida**

---

## 📄 Licença

Este projeto está sob a licença MIT.

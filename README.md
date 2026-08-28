# 🎯 Gerador de Apostas Lotofácil

Aplicação desktop desenvolvida em **C# com Windows Forms (.NET 10)**, para gerar, gerenciar, conferir e acompanhar apostas da Lotofácil com inteligência baseada em histórico de resultados oficiais.

![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-blue)
![EF Core](https://img.shields.io/badge/ORM-Entity%20Framework%20Core-green)
![SQL Server](https://img.shields.io/badge/DB-SQL%20Server-red)

---

## 🚀 Funcionalidades

### Usuário Comum
- 🎲 **Geração inteligente de jogos** — algoritmo que usa os 12 números mais frequentes nos resultados oficiais + 3 aleatórios, garantindo jogos inéditos
- 📋 **Listagem de apostas** — visualização com quantidade de acertos por jogo (conferência automática)
- 📊 **Dashboard pessoal** — cards com totais, melhor acerto, gráfico de distribuição de acertos, top 10 números mais usados
- 📥 **Exportação CSV** — exporta apostas para arquivo

### Administrador / Admin
- ⬇️ **Importação de resultados** — busca automática de sorteios oficiais via RPA (LoteriasCaixaRobot)
- 🛡️ **Painel Administrativo** — dashboard exclusivo com estatísticas dos sorteios importados:
  - Total de sorteios importados
  - Números mais e menos sorteados (top 15)
  - Últimos 10 sorteios oficiais
  - Detecção de jogos repetidos

### Sistema
- 🔐 **Autenticação segura** — senhas com hash BCrypt, migração automática de hashes legados
- 👤 **Perfis de acesso** — Usuario, Administrador, Admin (controle de visibilidade por perfil)
- 🔄 **Navegação SPA-like** — troca de telas dentro de um painel sem múltiplas janelas

---

## 🧱 Arquitetura

```
📦 GeradorApostasLotofacil
 ┣ 📂 Domain              → Entidades (ApostaModel, JogoModel, UsuarioModel)
 ┣ 📂 Application         → Serviços e interfaces de negócio
 ┃   ┣ ApostaService         (gravar, listar)
 ┃   ┣ GeracaoService        (geração inteligente de jogos)
 ┃   ┣ ImportacaoService     (importação via RPA)
 ┃   ┣ ConferenciaService    (conferência de acertos)
 ┃   ┣ DashboardService      (dashboard do usuário)
 ┃   ┣ AdminDashboardService (dashboard administrativo)
 ┃   ┣ UsuarioService        (autenticação, cadastro)
 ┃   ┗ NavigationService     (navegação entre forms)
 ┣ 📂 Repository           → Acesso a dados (IApostaRepository, IUsuarioRepository)
 ┣ 📂 Infrastructure       → DbContext + configuração EF Core
 ┣ 📂 DTO                  → ViewModels de transferência
 ┣ 📂 Helper               → Utilitários (JogoHelper, ApostaGridViewModel)
 ┣ 📂 Session              → Sessão do usuário logado
 ┣ 📂 Migrations           → Migrations do EF Core (Code First)
 ┣ 📂 Dll                  → LoteriasCaixaRobot.dll (RPA)
 ┗ 📄 Forms                → Interface (Login, Cadastro, Gerar, Listar, Importar, Dashboard, DashboardAdmin)
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

- **SQL Server** com Entity Framework Core 10
- **Code First** — schema gerenciado por migrations
- Modelo de dados com JSON column para números dos jogos

### Configuração

A connection string está em `appsettings.json`:

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

A aplicação utiliza um tema escuro moderno construído com WinForms puro:

- **Paleta**: fundos em tons de (30,30,46) a (55,65,82), texto branco, acentos em azul/verde/laranja
- **Menu lateral** com ícones emoji e visibilidade condicional por perfil
- **DataGridView** estilizados com `AutoSizeColumnsMode.Fill`, linhas de 40px, seleção por linha
- **Gráficos** com custom painting (GDI+) — barras coloridas para distribuição de acertos
- **Cards** com métricas em destaque (fontes grandes, cores por categoria)
- **Janela borderless** com title bar customizada e controles de janela unicode

---

## 🔐 Segurança

- Senhas hasheadas com **BCrypt** (work factor padrão)
- Migração automática: se um hash legado (SHA256) é detectado no login, é atualizado para BCrypt transparentemente
- Connection string em arquivo externo (`appsettings.json`), fora do código-fonte
- Perfis de acesso controlam visibilidade de funcionalidades na UI

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

2. Configure a connection string em `GeradorApostasLotofacil/appsettings.json`

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
| **Usuario** | Gerar apostas, listar, dashboard pessoal, exportar CSV |
| **Administrador** | Tudo do Usuario + Importar resultados + Painel Admin |
| **Admin** | Mesmo que Administrador |

---

## 🧪 Possíveis Melhorias

- 📈 Gráfico de evolução de acertos ao longo do tempo
- 🎯 Conferência automática com notificação ao atingir 11+ acertos
- 🌐 Integração REST API para resultados (substituir DLL)
- 🔍 Filtros avançados (por data, concurso, faixa de acertos)
- 🧪 Testes unitários com xUnit + Moq
- 📱 Versão MAUI para cross-platform

---

## ⚠️ Observações

- Este projeto tem fins **educacionais** e de prática de arquitetura
- Não garante qualquer vantagem estatística em jogos de loteria
- A DLL `LoteriasCaixaRobot.dll` realiza web scraping do site da Caixa — use com responsabilidade

---

## 👨‍💻 Autor

Desenvolvido por **Wellington Almeida**

---

## 📄 Licença

Este projeto está sob a licença MIT.

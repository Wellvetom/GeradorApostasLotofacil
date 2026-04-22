# 🎯 Gerador de Apostas Lotofácil (WinForms + .NET)

Aplicação desktop desenvolvida em **C# com Windows Forms**, com o objetivo de gerar, gerenciar e acompanhar apostas da Lotofácil utilizando uma arquitetura em camadas e boas práticas de desenvolvimento.

---

## 🚀 Funcionalidades

* 🔢 Geração automática de jogos da Lotofácil (15 números)
* 🧾 Cadastro manual de apostas
* 👤 Sistema de autenticação (Login/Cadastro de usuário)
* 💾 Persistência de dados com **Entity Framework Core**
* 📊 Listagem de apostas e jogos gerados
* 🔎 Exibição de:

  * Números do jogo
  * Usuário que realizou a aposta
  * Data de inclusão
* 🔄 Navegação entre telas dentro de um painel (SPA-like no WinForms)

---

## 🧱 Arquitetura do Projeto

O projeto segue uma separação em camadas:

```bash
📦 Solution
 ┣ 📂 Domain          → Entidades e regras de negócio
 ┣ 📂 Application     → Casos de uso (Services)
 ┣ 📂 Infrastructure  → Acesso a dados (EF Core, Repositories)
 ┗ 📂 WinForms        → Interface do usuário
```

---

## 🧠 Conceitos aplicados

* ✔️ Clean Architecture (simplificada)
* ✔️ Injeção de dependência manual
* ✔️ Repository Pattern
* ✔️ Separation of Concerns
* ✔️ Entity Framework Core (Code First + Migrations)
* ✔️ LINQ (Select / SelectMany / Projection)
* ✔️ ViewModel para exibição em UI

---

## 🗄️ Banco de Dados

* Utiliza **SQL Server**
* Mapeamento feito com **Entity Framework Core**
* Abordagem **Code First**

### 🔧 Criar banco via migration:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 🔐 Autenticação

* Sistema de login com validação de usuário
* Senhas armazenadas com hash (**BCrypt recomendado**)
* Sessão de usuário mantida durante a execução da aplicação

---

## 🖥️ Interface

* Aplicação construída com **Windows Forms**
* Navegação dinâmica utilizando um `Panel`
* Troca de telas sem abrir múltiplas janelas

---

## 📊 Exibição de Dados

A aplicação utiliza projeções com LINQ para exibir dados combinados:

* Jogos + Apostas + Usuários
* Utilização de `SelectMany` para flatten de coleções

---

## ⚙️ Tecnologias Utilizadas

* .NET (C#)
* Windows Forms
* Entity Framework Core
* SQL Server
* LINQ
* BCrypt (hash de senha)

---

## 🧪 Possíveis Melhorias

* 📈 Dashboard com estatísticas de jogos
* 🎯 Conferência automática de resultados
* 🌐 Integração com API de resultados da Lotofácil
* 🔍 Filtros por usuário/data/concurso

---

## ⚠️ Observações

* Este projeto tem fins educacionais e de prática de arquitetura
* Não garante qualquer vantagem estatística em jogos de loteria

---

## 👨‍💻 Autor

Desenvolvido por **Wellington Almeida**

---

## 📄 Licença

Este projeto está sob a licença MIT.

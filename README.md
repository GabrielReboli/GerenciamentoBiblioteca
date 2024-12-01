
# Gerenciamento de Biblioteca

Este projeto implementa um sistema de gerenciamento de biblioteca utilizando **C#** e **Windows Forms**, com integração ao banco de dados **MariaDB**. Ele permite realizar operações **CRUD** (Criar, Ler, Atualizar, Excluir) para **Livros**, **Membros** e **Empréstimos**. O padrão **Singleton** foi utilizado para gerenciar a conexão com o banco de dados.

---

## 🔗 Link para o Arquivo

Como o projeto é muito grande, ele foi hospedado no Google Drive. Clique no link abaixo para baixar o arquivo compactado:

**[Download do Projeto no Google Drive](https://drive.google.com/file/d/1Y1-GlSb9Ubfx3qHy9vP4yhw_CZp7UwoT/view?usp=sharing)**

---

## ⚙️ Funcionalidades

- **Livros:**
  - Adicionar, atualizar, excluir e listar livros.
- **Membros:**
  - Adicionar, atualizar, excluir e listar membros.
- **Empréstimos:**
  - Adicionar, atualizar, excluir e listar registros de empréstimos.
  - Relacionar livros e membros.

---

## 🗂 Estrutura do Arquivo `.zip`

A pasta contém os seguintes arquivos:
- **`GerenciamentoBiblioteca/`**: Diretório contendo os arquivos principais do projeto Visual Studio.
- **`packages/`**: Diretório contendo os pacotes NuGet necessários para o projeto.
- **`Biblioteca.sql`**: Script SQL para criação do banco de dados e inserção de dados iniciais.
- **`GerenciamentoBiblioteca.sln`**: Arquivo de solução do Visual Studio para abrir o projeto.
- **`projeto_biblioteca.pdf`**: Relatório detalhado explicando o funcionamento e a estrutura do projeto.

---

## 🛠 Pré-requisitos

Antes de executar o projeto, certifique-se de ter os seguintes softwares instalados:
1. [Visual Studio](https://visualstudio.microsoft.com/) com suporte ao desenvolvimento em C# e Windows Forms.
2. [MariaDB](https://mariadb.org/) para gerenciar o banco de dados.
3. [MySQL Workbench](https://www.mysql.com/products/workbench/) ou outro cliente para gerenciar o banco de dados.

---

## 🚀 Como Usar

1. **Configuração do Banco de Dados:**
   - Abra o MySQL Workbench.
   - Crie um banco de dados chamado `Biblioteca` e execute o script `Biblioteca.sql`.
    
2. **Configuração do Visual Studio:**
   - Extraia os arquivos do `.zip` para uma pasta.
   - Abra o arquivo `GerenciamentoBiblioteca.sln` no Visual Studio.
   - Certifique-se de que as dependências estão instaladas:
     - `MySql.Data` pelo **NuGet**.
   - Altere a string de conexão no arquivo `DatabaseConnection.cs`, se necessário:
     ```csharp
     private static readonly string _connectionString = "Server=localhost;Database=Biblioteca;User ID=root;Password=123456;";
     ```

3. **Execução:**
   - No Visual Studio, pressione **F5** ou clique em **Executar** para iniciar a aplicação.

---

## 📝 Considerações sobre o Projeto

### 1. **Padrão Singleton**
O padrão Singleton foi utilizado no arquivo `DatabaseConnection.cs` para garantir que apenas uma instância da conexão com o banco de dados seja criada durante o ciclo de vida da aplicação.

### 2. **Modelo de Dados**
As tabelas foram projetadas para simular uma biblioteca real:
- **Livros:** Inclui título, autor, data de publicação e categoria.
- **Membros:** Nome, e-mail e telefone.
- **Empréstimos:** Relaciona livros com membros.

### 3. **Validação**
A aplicação valida as entradas de dados e exibe mensagens de erro caso algum campo obrigatório esteja vazio.

---

## 📝 Relatório

Para mais detalhes sobre o projeto, incluindo decisões de design e explicações técnicas, consulte o arquivo `projeto_biblioteca.pdf`.

---

## 📜 Licença

Este projeto é de uso acadêmico e não deve ser distribuído ou comercializado sem a devida autorização.

---



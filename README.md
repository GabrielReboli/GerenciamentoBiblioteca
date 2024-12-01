
# Gerenciamento de Biblioteca

Este projeto implementa um sistema de gerenciamento de biblioteca utilizando **C#** e **Windows Forms**, com integração ao banco de dados **MariaDB**. Ele permite realizar operações **CRUD** (Criar, Ler, Atualizar, Excluir) para **Livros**, **Membros** e **Empréstimos**. O padrão **Singleton** foi utilizado para gerenciar a conexão com o banco de dados.

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

- **`Biblioteca.sln`:** Arquivo da solução do Visual Studio.
- **`DatabaseConnection.cs`:** Implementação do padrão Singleton para conexão com o banco de dados.
- **`Form1.cs`:** Código principal que implementa as operações CRUD e a interface gráfica.
- **`App.config`:** Configuração do projeto.
- **`Script_SQL.sql`:** Script para criar o banco de dados e popular tabelas com dados iniciais.
- **`README.md`:** Este arquivo com as instruções para uso.

---

## 🔗 Link para o Arquivo

Como o projeto é muito grande para ser enviado diretamente ao GitHub, ele foi hospedado no Google Drive. Clique no link abaixo para baixar o arquivo compactado:

**[Download do Projeto no Google Drive](https://drive.google.com/file/d/1Y1-GlSb9Ubfx3qHy9vP4yhw_CZp7UwoT/view?usp=sharing)**

---

## 🛠 Pré-requisitos

1. **Sistema Operacional:**
   - Windows 10 ou superior.

2. **Software Necessário:**
   - Visual Studio (versão recomendada: 2019 ou superior).
   - MariaDB instalado.
   - MySQL Workbench (opcional, para gerenciar o banco de dados visualmente).

3. **Configuração do Banco de Dados:**
   - Instale o MariaDB no computador.
   - Execute o script `Script_SQL.sql` no MySQL Workbench ou diretamente pelo terminal para criar e popular o banco de dados.

---

## 🚀 Como Usar

1. **Configuração do Banco de Dados:**
   - Abra o MySQL Workbench.
   - Crie um banco de dados chamado `Biblioteca` e execute o script `Script_SQL.sql`.
     ```sql
     SOURCE caminho_para/Script_SQL.sql;
     ```

2. **Configuração do Visual Studio:**
   - Extraia os arquivos do `.zip` para uma pasta.
   - Abra o arquivo `Biblioteca.sln` no Visual Studio.
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

## 📜 Licença

Este projeto é de uso acadêmico e não deve ser distribuído ou comercializado sem a devida autorização.

---

Se tiver dúvidas ou encontrar problemas, envie uma mensagem pelo e-mail do desenvolvedor.

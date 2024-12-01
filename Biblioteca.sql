-- Exclui o banco de dados se já existir
DROP DATABASE IF EXISTS Biblioteca;

-- Cria o banco de dados
CREATE DATABASE Biblioteca;
USE Biblioteca;

-- Cria a tabela Livros
CREATE TABLE Livros (
    LivroID INT AUTO_INCREMENT PRIMARY KEY,
    Titulo VARCHAR(255),
    Autor VARCHAR(255),
    DataPublicacao DATE,
    Categoria VARCHAR(100)
);

-- Cria a tabela Membros
CREATE TABLE Membros (
    MembroID INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Telefone VARCHAR(15) NOT NULL
);

-- Cria a tabela Empréstimos
CREATE TABLE Emprestimos (
    EmprestimoID INT AUTO_INCREMENT PRIMARY KEY,
    LivroID INT NOT NULL,
    MembroID INT NOT NULL,
    DataEmprestimo DATE NOT NULL,
    DataDevolucao DATE,
    FOREIGN KEY (LivroID) REFERENCES Livros(LivroID),
    FOREIGN KEY (MembroID) REFERENCES Membros(MembroID)
);

-- Insere dados na tabela Livros
INSERT INTO Livros (Titulo, Autor, DataPublicacao, Categoria) VALUES
('1984', 'George Orwell', '1949-06-08', 'Ficção Científica'),
('O Senhor dos Anéis', 'J.R.R. Tolkien', '1954-07-29', 'Fantasia'),
('Dom Casmurro', 'Machado de Assis', '1899-01-01', 'Literatura Brasileira'),
('A Origem das Espécies', 'Charles Darwin', '1859-11-24', 'Ciência'),
('Harry Potter e a Pedra Filosofal', 'J.K. Rowling', '1997-06-26', 'Fantasia'),
('O Pequeno Príncipe', 'Antoine de Saint-Exupéry', '1943-04-06', 'Infantil'),
('Orgulho e Preconceito', 'Jane Austen', '1813-01-28', 'Romance'),
('O Código Da Vinci', 'Dan Brown', '2003-03-18', 'Suspense'),
('A Revolução dos Bichos', 'George Orwell', '1945-08-17', 'Satírica'),
('A Divina Comédia', 'Dante Alighieri', '1320-01-01', 'Poesia');

-- Insere dados na tabela Membros
INSERT INTO Membros (Nome, Email, Telefone) VALUES
('João Silva', 'joao.silva@example.com', '11987654321'),
('Maria Souza', 'maria.souza@example.com', '11987654322'),
('Pedro Oliveira', 'pedro.oliveira@example.com', '11987654323'),
('Ana Clara', 'ana.clara@example.com', '11987654324'),
('Lucas Martins', 'lucas.martins@example.com', '11987654325');

-- Insere dados na tabela Empréstimos
INSERT INTO Emprestimos (LivroID, MembroID, DataEmprestimo, DataDevolucao) VALUES
(1, 1, '2024-01-01', '2024-01-15'),
(2, 2, '2024-01-10', '2024-01-25'),
(3, 3, '2024-01-05', '2024-01-20'),
(4, 4, '2024-01-08', '2024-01-22'),
(5, 5, '2024-01-12', '2024-01-27');

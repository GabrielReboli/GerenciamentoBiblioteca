using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GerenciamentoBiblioteca
{
    public partial class Form1 : Form
    {
        //private string connectionString = "Server=localhost;Database=Biblioteca;User ID=root;Password=123456;";

        // Controles
        private DataGridView dgvLivros, dgvMembros, dgvEmprestimos;
        private TextBox txtTitulo, txtAutor, txtCategoria, txtNome, txtEmail, txtTelefone;
        private DateTimePicker dtpDataPublicacao, dtpDataEmprestimo, dtpDataDevolucao;
        private ComboBox cbLivroID, cbMembroID;
        private Button btnAdd, btnUpdate, btnDelete, btnLoad, btnAddMembro, btnUpdateMembro, btnDeleteMembro, btnLoadMembros;
        private Button btnAddEmprestimo, btnUpdateEmprestimo, btnDeleteEmprestimo, btnLoadEmprestimos;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTable();
            LoadMembros();
            LoadEmprestimos();
            LoadCombos();
        }

        private void InitializeCustomComponents()
        {
            // Livros - DataGridView
            dgvLivros = new DataGridView
            {
                Location = new Point(20, 200),
                Size = new Size(600, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvLivros.SelectionChanged += dgvLivros_SelectionChanged;
            Controls.Add(dgvLivros);

            // Membros - DataGridView
            dgvMembros = new DataGridView
            {
                Location = new Point(650, 200),
                Size = new Size(600, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvMembros.SelectionChanged += dgvMembros_SelectionChanged;
            Controls.Add(dgvMembros);

            // Empréstimos - DataGridView
            dgvEmprestimos = new DataGridView
            {
                Location = new Point(20, 450),
                Size = new Size(1200, 200),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvEmprestimos.SelectionChanged += dgvEmprestimos_SelectionChanged;
            Controls.Add(dgvEmprestimos);

            // Livros - Campos
            txtTitulo = CreatePlaceholderTextBox("Título", new Point(20, 20));
            txtAutor = CreatePlaceholderTextBox("Autor", new Point(20, 60));
            txtCategoria = CreatePlaceholderTextBox("Categoria", new Point(20, 100));
            dtpDataPublicacao = new DateTimePicker { Location = new Point(20, 140), Width = 200 };
            Controls.Add(txtTitulo);
            Controls.Add(txtAutor);
            Controls.Add(txtCategoria);
            Controls.Add(dtpDataPublicacao);

            // Membros - Campos
            txtNome = CreatePlaceholderTextBox("Nome", new Point(650, 20));
            txtEmail = CreatePlaceholderTextBox("Email", new Point(650, 60));
            txtTelefone = CreatePlaceholderTextBox("Telefone", new Point(650, 100));
            Controls.Add(txtNome);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefone);

            // Empréstimos - Campos
            cbLivroID = new ComboBox { Location = new Point(20, 400), Width = 150 };
            cbMembroID = new ComboBox { Location = new Point(200, 400), Width = 150 };
            dtpDataEmprestimo = new DateTimePicker { Location = new Point(400, 400), Width = 200 };
            dtpDataDevolucao = new DateTimePicker { Location = new Point(650, 400), Width = 200 };
            Controls.Add(cbLivroID);
            Controls.Add(cbMembroID);
            Controls.Add(dtpDataEmprestimo);
            Controls.Add(dtpDataDevolucao);

            // Botões para Livros
            btnAdd = new Button { Text = "Adicionar Livro", Location = new Point(250, 20), Width = 120 };
            btnUpdate = new Button { Text = "Atualizar Livro", Location = new Point(250, 60), Width = 120 };
            btnDelete = new Button { Text = "Excluir Livro", Location = new Point(250, 100), Width = 120 };
            btnLoad = new Button { Text = "Carregar Livros", Location = new Point(250, 140), Width = 120 };
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnLoad.Click += (s, e) => LoadTable();
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnLoad);

            // Botões para Membros
            btnAddMembro = new Button { Text = "Adicionar Membro", Location = new Point(880, 20), Width = 150 };
            btnUpdateMembro = new Button { Text = "Atualizar Membro", Location = new Point(880, 60), Width = 150 };
            btnDeleteMembro = new Button { Text = "Excluir Membro", Location = new Point(880, 100), Width = 150 };
            btnLoadMembros = new Button { Text = "Carregar Membros", Location = new Point(880, 140), Width = 150 };
            btnAddMembro.Click += btnAddMembro_Click;
            btnUpdateMembro.Click += btnUpdateMembro_Click;
            btnDeleteMembro.Click += btnDeleteMembro_Click;
            btnLoadMembros.Click += (s, e) => LoadMembros();
            Controls.Add(btnAddMembro);
            Controls.Add(btnUpdateMembro);
            Controls.Add(btnDeleteMembro);
            Controls.Add(btnLoadMembros);

            // Botões para Empréstimos
            btnAddEmprestimo = new Button { Text = "Adicionar Empréstimo", Location = new Point(900, 400), Width = 150 };
            btnUpdateEmprestimo = new Button { Text = "Atualizar Empréstimo", Location = new Point(1060, 400), Width = 150 };
            btnDeleteEmprestimo = new Button { Text = "Excluir Empréstimo", Location = new Point(900, 370), Width = 150 };
            btnLoadEmprestimos = new Button { Text = "Carregar Empréstimos", Location = new Point(1060, 370), Width = 150 };
            btnAddEmprestimo.Click += btnAddEmprestimo_Click;
            btnUpdateEmprestimo.Click += btnUpdateEmprestimo_Click;
            btnDeleteEmprestimo.Click += btnDeleteEmprestimo_Click;
            btnLoadEmprestimos.Click += (s, e) => LoadEmprestimos();
            Controls.Add(btnAddEmprestimo);
            Controls.Add(btnUpdateEmprestimo);
            Controls.Add(btnDeleteEmprestimo);
            Controls.Add(btnLoadEmprestimos);

            // Eventos para Livros
            dgvLivros.SelectionChanged += dgvLivros_SelectionChanged;

            // Eventos para Membros
            dgvMembros.SelectionChanged += dgvMembros_SelectionChanged;

            // Eventos para Empréstimos
            dgvEmprestimos.SelectionChanged += dgvEmprestimos_SelectionChanged;

        }

        private TextBox CreatePlaceholderTextBox(string placeholder, Point location)
        {
            var textBox = new TextBox
            {
                Location = location,
                Width = 200,
                Text = placeholder,
                ForeColor = Color.Gray
            };
            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };
            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                }
            };
            return textBox;
        }

        // Métodos CRUD
        private void LoadTable()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Livros";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvLivros.DataSource = dt;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Livros (Titulo, Autor, DataPublicacao, Categoria) VALUES (@Titulo, @Autor, @DataPublicacao, @Categoria)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                cmd.Parameters.AddWithValue("@Autor", txtAutor.Text);
                cmd.Parameters.AddWithValue("@DataPublicacao", dtpDataPublicacao.Value);
                cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Livro adicionado com sucesso!");
                //connection.Close();
                LoadTable();
            }
        }

        // Métodos restantes...
        private void LoadMembros()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM Membros";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvMembros.DataSource = dt;
            }
        }


        private void LoadEmprestimos()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }

                string query = "SELECT Emprestimos.EmprestimoID, Livros.Titulo AS Livro, Membros.Nome AS Membro, " +
                               "Emprestimos.DataEmprestimo, Emprestimos.DataDevolucao " +
                               "FROM Emprestimos " +
                               "INNER JOIN Livros ON Emprestimos.LivroID = Livros.LivroID " +
                               "INNER JOIN Membros ON Emprestimos.MembroID = Membros.MembroID";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvEmprestimos.DataSource = dt;
            }
        }


        private void dgvLivros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLivros.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvLivros.SelectedRows[0];
                txtTitulo.Text = selectedRow.Cells["Titulo"].Value.ToString();
                txtAutor.Text = selectedRow.Cells["Autor"].Value.ToString();
                txtCategoria.Text = selectedRow.Cells["Categoria"].Value.ToString();
                dtpDataPublicacao.Value = Convert.ToDateTime(selectedRow.Cells["DataPublicacao"].Value);
            }
        }

        private void dgvMembros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembros.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMembros.SelectedRows[0];
                txtNome.Text = selectedRow.Cells["Nome"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtTelefone.Text = selectedRow.Cells["Telefone"].Value.ToString();
            }
        }

        private void dgvEmprestimos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmprestimos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEmprestimos.SelectedRows[0];
                cbLivroID.SelectedValue = selectedRow.Cells["Livro"].Value.ToString();
                cbMembroID.SelectedValue = selectedRow.Cells["Membro"].Value.ToString();
                dtpDataEmprestimo.Value = Convert.ToDateTime(selectedRow.Cells["DataEmprestimo"].Value);
                dtpDataDevolucao.Value = Convert.ToDateTime(selectedRow.Cells["DataDevolucao"].Value);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvLivros.SelectedRows.Count > 0)
            {
                int livroId = Convert.ToInt32(dgvLivros.SelectedRows[0].Cells["LivroID"].Value);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Livros SET Titulo = @Titulo, Autor = @Autor, DataPublicacao = @DataPublicacao, Categoria = @Categoria WHERE LivroID = @LivroID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Titulo", txtTitulo.Text);
                    cmd.Parameters.AddWithValue("@Autor", txtAutor.Text);
                    cmd.Parameters.AddWithValue("@DataPublicacao", dtpDataPublicacao.Value);
                    cmd.Parameters.AddWithValue("@Categoria", txtCategoria.Text);
                    cmd.Parameters.AddWithValue("@LivroID", livroId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Livro atualizado com sucesso!");
                    //connection.Close();
                    LoadTable();
                }
            }
            else
            {
                MessageBox.Show("Selecione um livro para atualizar!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLivros.SelectedRows.Count > 0)
            {
                int livroId = Convert.ToInt32(dgvLivros.SelectedRows[0].Cells["LivroID"].Value);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM Livros WHERE LivroID = @LivroID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@LivroID", livroId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Livro excluído com sucesso!");
                    //connection.Close();
                    LoadTable();
                }
            }
            else
            {
                MessageBox.Show("Selecione um livro para excluir!");
            }
        }

        private void btnAddMembro_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Membros (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Membro adicionado com sucesso!");
                //connection.Close();
                LoadMembros();
            }
        }

        private void btnDeleteMembro_Click(object sender, EventArgs e)
        {
            if (dgvMembros.SelectedRows.Count > 0)
            {
                int membroId = Convert.ToInt32(dgvMembros.SelectedRows[0].Cells["MembroID"].Value);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM Membros WHERE MembroID = @MembroID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MembroID", membroId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Membro excluído com sucesso!");
                    //connection.Close();
                    LoadMembros();
                }
            }
            else
            {
                MessageBox.Show("Selecione um membro para excluir!");
            }
        }

        private void btnAddEmprestimo_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Emprestimos (LivroID, MembroID, DataEmprestimo, DataDevolucao) " +
                               "VALUES (@LivroID, @MembroID, @DataEmprestimo, @DataDevolucao)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@LivroID", cbLivroID.SelectedValue);
                cmd.Parameters.AddWithValue("@MembroID", cbMembroID.SelectedValue);
                cmd.Parameters.AddWithValue("@DataEmprestimo", dtpDataEmprestimo.Value);
                cmd.Parameters.AddWithValue("@DataDevolucao", dtpDataDevolucao.Value);

                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Empréstimo adicionado com sucesso!");
                //connection.Close();
                LoadEmprestimos();
            }
        }

        private void btnDeleteEmprestimo_Click(object sender, EventArgs e)
        {
            if (dgvEmprestimos.SelectedRows.Count > 0)
            {
                int emprestimoId = Convert.ToInt32(dgvEmprestimos.SelectedRows[0].Cells["EmprestimoID"].Value);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "DELETE FROM Emprestimos WHERE EmprestimoID = @EmprestimoID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@EmprestimoID", emprestimoId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empréstimo excluído com sucesso!");
                    //connection.Close();
                    LoadEmprestimos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um empréstimo para excluir!");
            }
        }

        private void LoadCombos()
        {
            using (MySqlConnection connection = DatabaseConnection.GetConnection())
            {
                // Carregar Livros no ComboBox
                string queryLivros = "SELECT LivroID, Titulo FROM Livros";
                MySqlDataAdapter adapterLivros = new MySqlDataAdapter(queryLivros, connection);
                DataTable dtLivros = new DataTable();
                adapterLivros.Fill(dtLivros);
                cbLivroID.DataSource = dtLivros;
                cbLivroID.DisplayMember = "Titulo";
                cbLivroID.ValueMember = "LivroID";

                // Carregar Membros no ComboBox
                string queryMembros = "SELECT MembroID, Nome FROM Membros";
                MySqlDataAdapter adapterMembros = new MySqlDataAdapter(queryMembros, connection);
                DataTable dtMembros = new DataTable();
                adapterMembros.Fill(dtMembros);
                cbMembroID.DataSource = dtMembros;
                cbMembroID.DisplayMember = "Nome";
                cbMembroID.ValueMember = "MembroID";
            }
        }

        private void btnUpdateMembro_Click(object sender, EventArgs e)
        {
            if (dgvMembros.SelectedRows.Count > 0)
            {
                int membroId = Convert.ToInt32(dgvMembros.SelectedRows[0].Cells["MembroID"].Value);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Membros SET Nome = @Nome, Email = @Email, Telefone = @Telefone WHERE MembroID = @MembroID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txtTelefone.Text);
                    cmd.Parameters.AddWithValue("@MembroID", membroId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Membro atualizado com sucesso!");
                    //connection.Close();
                    LoadMembros();
                }
            }
            else
            {
                MessageBox.Show("Selecione um membro para atualizar!");
            }
        }

        private void btnUpdateEmprestimo_Click(object sender, EventArgs e)
        {
            if (dgvEmprestimos.SelectedRows.Count > 0)
            {
                int emprestimoId = Convert.ToInt32(dgvEmprestimos.SelectedRows[0].Cells["EmprestimoID"].Value);

                using (MySqlConnection connection = DatabaseConnection.GetConnection())
                {
                    string query = "UPDATE Emprestimos SET LivroID = @LivroID, MembroID = @MembroID, DataEmprestimo = @DataEmprestimo, DataDevolucao = @DataDevolucao WHERE EmprestimoID = @EmprestimoID";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@LivroID", cbLivroID.SelectedValue);
                    cmd.Parameters.AddWithValue("@MembroID", cbMembroID.SelectedValue);
                    cmd.Parameters.AddWithValue("@DataEmprestimo", dtpDataEmprestimo.Value);
                    cmd.Parameters.AddWithValue("@DataDevolucao", dtpDataDevolucao.Value);
                    cmd.Parameters.AddWithValue("@EmprestimoID", emprestimoId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empréstimo atualizado com sucesso!");
                    //connection.Close();
                    LoadEmprestimos();
                }
            }
            else
            {
                MessageBox.Show("Selecione um empréstimo para atualizar!");
            }
        }



    }
}

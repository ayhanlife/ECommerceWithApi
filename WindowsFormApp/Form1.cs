using Entities.Dtos.User;

using System.Net.Http.Json;

namespace WindowsFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string url = "https://localhost:7194/api/";
        private async void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private async Task Listele()
        {
            using (HttpClient client = new HttpClient())
            {
                var users = await client.GetFromJsonAsync<List<UserDetailDto>>(new Uri(url + "Values/GetList"));
                Grid1.DataSource = users;
            }
        }
        private void ComboBox()
        {
            List<Gender> genders = new List<Gender>()
            {
                new Gender {Id=1, GenderName ="Erkek"},
                new Gender {Id=2, GenderName ="Kadýn"},
            };
        }
        private class Gender
        {
            public int Id { get; set; }
            public string GenderName { get; set; }
        }
        private void TEMIZLE()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            dtDateOf.Value = DateTime.Now;
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            txtAdres.Text = "";
            comboBox1.SelectedValue = 0;
        }
        private async void button1_Click(object sender, EventArgs e)
        {

            using (HttpClient client = new HttpClient())
            {
                UserAddDto dto = new UserAddDto()
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dtDateOf.Value,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    UserName = txtUsername.Text,
                    Adress = txtAdres.Text,
                    Gender = comboBox1.Text == "Erkek" ? true : false,
                };
                HttpResponseMessage httpResponse = await client.PostAsJsonAsync(url + "Users/Add", dto);
                if (httpResponse.IsSuccessStatusCode)
                {
                    await Listele();
                    MessageBox.Show("Ýþlem baþarý ile tamamlandý");
                    TEMIZLE();
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //GUNCELLE
            using (HttpClient client = new HttpClient())
            {
                UserUpdateDto dto = new UserUpdateDto()
                {
                    Id = Convert.ToInt32(LId.Text),
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    DateOfBirth = dtDateOf.Value,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    UserName = txtUsername.Text,
                    Adress = txtAdres.Text,
                    Gender = comboBox1.Text == "Erkek" ? true : false,
                };
                HttpResponseMessage httpResponse = await client.PostAsJsonAsync(url + "Users/uPDATE", dto);
                if (httpResponse.IsSuccessStatusCode)
                {
                    await Listele();
                    MessageBox.Show("Ýþlem baþarý ile tamamlandý");
                    TEMIZLE();
                }
            }
        }

        private async void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            int Id = Convert.ToInt32(Grid1.Rows[e.RowIndex].Cells["Id"].Value);
            LId.Text = Id.ToString();
            using (HttpClient client = new HttpClient())
            {

                var user = await client.GetFromJsonAsync<UserDto>(url + "Users/GetById/" + Id);


                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                dtDateOf.Value = user.DateOfBirth;
                txtEmail.Text = user.Email;
                txtPassword.Text = user.Password;
                txtUsername.Text = user.UserName;
                txtAdres.Text = user.Adress;
                comboBox1.SelectedValue = user.Gender == true ? 1 : 2;
            }
        }
    }
}
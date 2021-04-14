using MyTrunfo.Enums;
using MyTrunfo.Model;
using MyTrunfo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTrunfo
{
    public partial class Form1 : Form
    {
        public List<Car> AllCards { get; set; }
        public List<Car> Player1Cards { get; set; }
        public List<Car> Player2Cards { get; set; }

        public Form1()
        {
            InitializeComponent();
            PrepareEnvironment();
        }

        private void PrepareEnvironment()
        {
            ResetThumbs(EPlayer.Player1);
            ResetThumbs(EPlayer.Player2);
            CloseCard(EPlayer.Player1);
            CloseCard(EPlayer.Player2);
            CreateCards();
            ShuffleCards();
        }

        private void CreateCards()
        {
            AllCards = new List<Car>();
            AllCards.Add(new Car() { Id = 1, Code = "C2", Name = "Alure 408", Brand = "Peugeot", Country = ECountry.France, Consumption = 12.8m, HorsePower = 115, Length = 4159, MaxSpeed = 185, Displacements = 1600, Price = 83 });
            AllCards.Add(new Car() { Id = 2, Code = "A6", Name = "Amarok", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 8.4m, HorsePower = 180, Length = 5254, MaxSpeed = 179, Displacements = 2000, Price = 243 });
            AllCards.Add(new Car() { Id = 3, Code = "A2", Name = "Astra", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 10.7m, HorsePower = 128, Length = 4199, MaxSpeed = 201, Displacements = 2000, Price = 29 });
            AllCards.Add(new Car() { Id = 4, Code = "C1", Name = "Bandeirantes", Brand = "Toyota", Country = ECountry.Japan, Consumption = 9m, HorsePower = 96, Length = 5300, MaxSpeed = 125, Displacements = 3661, Price = 40 });
            AllCards.Add(new Car() { Id = 5, Code = "C3", Name = "C3", Brand = "Citroën", Country = ECountry.France, Consumption = 16.6m, HorsePower = 90, Length = 3944, MaxSpeed = 171, Displacements = 1200, Price = 62 });
            AllCards.Add(new Car() { Id = 6, Code = "B2", Name = "Celta", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 12.9m, HorsePower = 78, Length = 3788, MaxSpeed = 161, Displacements = 1000, Price = 28 });
            AllCards.Add(new Car() { Id = 7, Code = "D8", Name = "Classic", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 13.6m, HorsePower = 78, Length = 4152, MaxSpeed = 166, Displacements = 1000, Price = 30 });
            AllCards.Add(new Car() { Id = 8, Code = "B4", Name = "Corola", Brand = "Toyota", Country = ECountry.Japan, Consumption = 13.9m, HorsePower = 177, Length = 4630, MaxSpeed = 199, Displacements = 2000, Price = 123 });
            AllCards.Add(new Car() { Id = 9, Code = "D3", Name = "Corsa Joy", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 10.9m, HorsePower = 78, Length = 3822, MaxSpeed = 166, Displacements = 1000, Price = 16 });
            AllCards.Add(new Car() { Id = 10, Code = "B3", Name = "Cruze", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 14m, HorsePower = 153, Length = 4665, MaxSpeed = 214, Displacements = 1400, Price = 120 });
            AllCards.Add(new Car() { Id = 11, Code = "A4", Name = "Ecosport", Brand = "Ford", Country = ECountry.USA, Consumption = 8.8m, HorsePower = 107, Length = 4240, MaxSpeed = 165, Displacements = 1598, Price = 31 });
            AllCards.Add(new Car() { Id = 12, Code = "C7", Name = "Etios", Brand = "Toyota", Country = ECountry.Japan, Consumption = 9.8m, HorsePower = 107, Length = 3884, MaxSpeed = 187, Displacements = 1500, Price = 56 });
            AllCards.Add(new Car() { Id = 13, Code = "B8", Name = "Fiesta", Brand = "Ford", Country = ECountry.USA, Consumption = 12m, HorsePower = 73, Length = 3930, MaxSpeed = 146, Displacements = 1000, Price = 19 });
            AllCards.Add(new Car() { Id = 14, Code = "A1", Name = "Fox Trend", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 12.2m, HorsePower = 76, Length = 3823, MaxSpeed = 132, Displacements = 1000, Price = 54 });
            AllCards.Add(new Car() { Id = 15, Code = "A8", Name = "Fusion", Brand = "Ford", Country = ECountry.USA, Consumption = 11.7m, HorsePower = 248, Length = 4871, MaxSpeed = 195, Displacements = 2000, Price = 150 });
            AllCards.Add(new Car() { Id = 16, Code = "B5", Name = "Gol G1", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 7.5m, HorsePower = 96, Length = 3810, MaxSpeed = 170, Displacements = 1781, Price = 8 });
            AllCards.Add(new Car() { Id = 17, Code = "B1", Name = "Gol G4", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 10.8m, HorsePower = 71, Length = 3931, MaxSpeed = 168, Displacements = 1000, Price = 16 });
            AllCards.Add(new Car() { Id = 18, Code = "A3", Name = "Hilux", Brand = "Toyota", Country = ECountry.Japan, Consumption = 9m, HorsePower = 163, Length = 5325, MaxSpeed = 180, Displacements = 2700, Price = 145 });
            AllCards.Add(new Car() { Id = 19, Code = "D5", Name = "Ka", Brand = "Ford", Country = ECountry.USA, Consumption = 9.6m, HorsePower = 73, Length = 3836, MaxSpeed = 160, Displacements = 1000, Price = 15 });
            AllCards.Add(new Car() { Id = 20, Code = "A0", Name = "Kombi", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 8.4m, HorsePower = 80, Length = 4505, MaxSpeed = 130, Displacements = 1390, Price = 27 });
            AllCards.Add(new Car() { Id = 21, Code = "D2", Name = "L200", Brand = "Mitsubishi", Country = ECountry.Japan, Consumption = 13.2m, HorsePower = 190, Length = 5280, MaxSpeed = 179, Displacements = 2400, Price = 172 });
            AllCards.Add(new Car() { Id = 22, Code = "B9", Name = "Logan", Brand = "Renault", Country = ECountry.France, Consumption = 10.2m, HorsePower = 82, Length = 4349, MaxSpeed = 164, Displacements = 1000, Price = 63 });
            AllCards.Add(new Car() { Id = 23, Code = "B6", Name = "Master", Brand = "Renault", Country = ECountry.France, Consumption = 8.1m, HorsePower = 130, Length = 5642, MaxSpeed = 145, Displacements = 2300, Price = 173 });
            AllCards.Add(new Car() { Id = 24, Code = "A9", Name = "Montana", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 12.1m, HorsePower = 99, Length = 4514, MaxSpeed = 170, Displacements = 1400, Price = 75 });
            AllCards.Add(new Car() { Id = 25, Code = "A7", Name = "Omega GLS", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 7.5m, HorsePower = 116, Length = 4738, MaxSpeed = 189, Displacements = 2000, Price = 8 });
            AllCards.Add(new Car() { Id = 26, Code = "C4", Name = "Palio Weekend", Brand = "Fiat", Country = ECountry.Italy, Consumption = 11.1m, HorsePower = 132, Length = 4310, MaxSpeed = 184, Displacements = 1700, Price = 65 });
            AllCards.Add(new Car() { Id = 27, Code = "D6", Name = "Polo", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 13.9m, HorsePower = 128, Length = 4053, MaxSpeed = 192, Displacements = 1000, Price = 58 });
            AllCards.Add(new Car() { Id = 28, Code = "D9", Name = "Ranger 3.0", Brand = "Ford", Country = ECountry.USA, Consumption = 10.4m, HorsePower = 163, Length = 5143, MaxSpeed = 170, Displacements = 3000, Price = 167 });
            AllCards.Add(new Car() { Id = 29, Code = "D1", Name = "Renegade", Brand = "Jeep", Country = ECountry.USA, Consumption = 12.2m, HorsePower = 139, Length = 4232, MaxSpeed = 182, Displacements = 1700, Price = 70 });
            AllCards.Add(new Car() { Id = 30, Code = "A5", Name = "S10", Brand = "Chevrolet", Country = ECountry.USA, Consumption = 8.2m, HorsePower = 206, Length = 5347, MaxSpeed = 163, Displacements = 2500, Price = 68 });
            AllCards.Add(new Car() { Id = 31, Code = "B7", Name = "Saveiro Surf", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 11.3m, HorsePower = 99, Length = 4451, MaxSpeed = 165, Displacements = 1600, Price = 26 });
            AllCards.Add(new Car() { Id = 32, Code = "B0", Name = "Serie 4 428", Brand = "BMW", Country = ECountry.Germany, Consumption = 12.1m, HorsePower = 245, Length = 4638, MaxSpeed = 250, Displacements = 2000, Price = 311 });
            AllCards.Add(new Car() { Id = 33, Code = "C9", Name = "Siena", Brand = "Fiat", Country = ECountry.Italy, Consumption = 13.2m, HorsePower = 86, Length = 4115, MaxSpeed = 167, Displacements = 1400, Price = 31 });
            AllCards.Add(new Car() { Id = 34, Code = "D0", Name = "Spacefox", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 9.4m, HorsePower = 104, Length = 4204, MaxSpeed = 177, Displacements = 1600, Price = 41 });
            AllCards.Add(new Car() { Id = 35, Code = "C6", Name = "Tiguan", Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 9.6m, HorsePower = 220, Length = 4705, MaxSpeed = 223, Displacements = 2000, Price = 225 });
            AllCards.Add(new Car() { Id = 36, Code = "D7", Name = "Toro", Brand = "Fiat", Country = ECountry.Italy, Consumption = 11.2m, HorsePower = 139, Length = 4915, MaxSpeed = 181, Displacements = 1700, Price = 100 });
            AllCards.Add(new Car() { Id = 37, Code = "C8", Name = "Tucson", Brand = "Hyundai", Country = ECountry.SouthCorea, Consumption = 15.1m, HorsePower = 143,Length = 4325,MaxSpeed = 180,Displacements = 2000,Price = 155 });
            AllCards.Add(new Car() { Id = 38,Code = "C0",Name = "Uno",Brand = "Fiat",Country = ECountry.Italy,Consumption = 8.5m,HorsePower = 57,Length = 3644,MaxSpeed = 151,Displacements = 1000,Price = 9 });
            AllCards.Add(new Car() { Id = 39,Code = "C5",Name = "Vectra",Brand = "Chevrolet",Country = ECountry.USA,Consumption = 8.2m,HorsePower = 123,Length = 4495,MaxSpeed = 195,Displacements = 2198,Price = 15 });
            AllCards.Add(new Car() { Id = 40,Code = "D4",Name = "Zafira",Brand = "Chevrolet",Country = ECountry.USA,Consumption = 9.4m,HorsePower = 140,Length = 4334,MaxSpeed = 181,Displacements = 2000,Price = 30 });
        }

        private void ShuffleCards()
        {
            throw new NotImplementedException();
        }

        private void CloseCard(EPlayer player1)
        {
            throw new NotImplementedException();
        }

        private void ResetThumbs(EPlayer player1)
        {
            throw new NotImplementedException();
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            picThumb21Player1.Visible = false;
            this.picCarPlayer1.Image = Resources.Saveiro_Surf;
            this.picCarPlayer1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn02_Click(object sender, EventArgs e)
        {

        }
    }
}

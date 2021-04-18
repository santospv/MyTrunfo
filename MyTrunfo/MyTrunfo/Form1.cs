using MyTrunfo.Enums;
using MyTrunfo.Model;
using MyTrunfo.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MyTrunfo
{
    public partial class Form1 : Form
    {
        #region properties
        public List<Car> AllCards { get; set; }
        public List<Car> Player1Cards { get; set; }
        public List<Car> Player2Cards { get; set; }
        public List<Car> TiedCards { get; set; }
        public Boolean Player1IsVisible { get; set; }
        public Boolean Player2IsVisible { get; set; }
        public EPlayer CurrentWinner { get; set; }
        public EPlayer CurrentPlayer { get; set; }
        #endregion

        #region constructors
        public Form1()
        {
            InitializeComponent();
            PrepareEnvironment();
        }
        #endregion

        #region events
        private void btn01_Click(object sender, EventArgs e)
        {
            TurnCard(EPlayer.Player1);
        }

        private void btn02_Click(object sender, EventArgs e)
        {
            TurnCard(EPlayer.Player2);
        }

        private void lblConsumptionPlayer1_Click(object sender, EventArgs e)
        {
            Compare(ECategory.Consumption);
        }

        private void lblHorsePowerPlayer1_Click(object sender, EventArgs e)
        {
            Compare(ECategory.HorsePower);
        }

        private void lblLengthPlayer1_Click(object sender, EventArgs e)
        {
            Compare(ECategory.Length);
        }

        private void lblMaxSpeedPlayer1_Click(object sender, EventArgs e)
        {
            Compare(ECategory.MaxSpeed);
        }

        private void lblDisplacementsPlayer1_Click(object sender, EventArgs e)
        {
            Compare(ECategory.Displacements);
        }

        private void lblPricePlayer1_Click(object sender, EventArgs e)
        {
            Compare(ECategory.Price);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }
        #endregion

        #region private methods
        private void PrepareEnvironment()
        {
            TiedCards = new List<Car>();
            Player1IsVisible = true;
            Player2IsVisible = true;
            ResetThumbs(EPlayer.Player1);
            ResetThumbs(EPlayer.Player2);
            TurnCard(EPlayer.Player1);
            TurnCard(EPlayer.Player2);
            RefreshTiedPannel();
            CreateCards();
            ShuffleCards();
        }

        //private void CreateCards()
        //{
        //    AllCards = new List<Car>();
        //    AllCards.Add(new Car() { Id = 1, Code = "C2", Name = "Alure 408", Image = Resources.Alure_408, Brand = "Peugeot", Country = ECountry.France, Consumption = 12.8m, HorsePower = 115, Length = 4159, MaxSpeed = 185, Displacements = 1600, Price = 83 });
        //    AllCards.Add(new Car() { Id = 2, Code = "A6", Name = "Amarok", Image = Resources.Amarok, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 8.4m, HorsePower = 180, Length = 5254, MaxSpeed = 179, Displacements = 2000, Price = 243 });
        //    AllCards.Add(new Car() { Id = 3, Code = "A2", Name = "Astra", Image = Resources.Astra, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 10.7m, HorsePower = 128, Length = 4199, MaxSpeed = 201, Displacements = 2000, Price = 29 });
        //    AllCards.Add(new Car() { Id = 4, Code = "C1", Name = "Bandeirantes", Image = Resources.Bandeirantes, Brand = "Toyota", Country = ECountry.Japan, Consumption = 9m, HorsePower = 96, Length = 5300, MaxSpeed = 125, Displacements = 3661, Price = 40 });
        //    AllCards.Add(new Car() { Id = 5, Code = "C3", Name = "C3", Image = Resources.C3, Brand = "Citroën", Country = ECountry.France, Consumption = 16.6m, HorsePower = 90, Length = 3944, MaxSpeed = 171, Displacements = 1200, Price = 62 });
        //    AllCards.Add(new Car() { Id = 6, Code = "B2", Name = "Celta", Image = Resources.Celta, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 12.9m, HorsePower = 78, Length = 3788, MaxSpeed = 161, Displacements = 1000, Price = 28 });
        //    AllCards.Add(new Car() { Id = 7, Code = "D8", Name = "Classic", Image = Resources.Classic, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 13.6m, HorsePower = 78, Length = 4152, MaxSpeed = 166, Displacements = 1000, Price = 30 });
        //    AllCards.Add(new Car() { Id = 8, Code = "B4", Name = "Corola", Image = Resources.Corola, Brand = "Toyota", Country = ECountry.Japan, Consumption = 13.9m, HorsePower = 177, Length = 4630, MaxSpeed = 199, Displacements = 2000, Price = 123 });
        //    AllCards.Add(new Car() { Id = 9, Code = "D3", Name = "Corsa Joy", Image = Resources.Corsa_Joy, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 10.9m, HorsePower = 78, Length = 3822, MaxSpeed = 166, Displacements = 1000, Price = 16 });
        //    AllCards.Add(new Car() { Id = 10, Code = "B3", Name = "Cruze", Image = Resources.Cruze, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 14m, HorsePower = 153, Length = 4665, MaxSpeed = 214, Displacements = 1400, Price = 120 });
        //    AllCards.Add(new Car() { Id = 11, Code = "A4", Name = "Ecosport", Image = Resources.Ecosport, Brand = "Ford", Country = ECountry.USA, Consumption = 8.8m, HorsePower = 107, Length = 4240, MaxSpeed = 165, Displacements = 1598, Price = 31 });
        //    AllCards.Add(new Car() { Id = 12, Code = "C7", Name = "Etios", Image = Resources.Etios, Brand = "Toyota", Country = ECountry.Japan, Consumption = 9.8m, HorsePower = 107, Length = 3884, MaxSpeed = 187, Displacements = 1500, Price = 56 });
        //    AllCards.Add(new Car() { Id = 13, Code = "B8", Name = "Fiesta", Image = Resources.Fiesta, Brand = "Ford", Country = ECountry.USA, Consumption = 12m, HorsePower = 73, Length = 3930, MaxSpeed = 146, Displacements = 1000, Price = 19 });
        //    AllCards.Add(new Car() { Id = 14, Code = "A1", Name = "Fox Trend", Image = Resources.Fox_Trend, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 12.2m, HorsePower = 76, Length = 3823, MaxSpeed = 132, Displacements = 1000, Price = 54 });
        //    AllCards.Add(new Car() { Id = 15, Code = "A8", Name = "Fusion", Image = Resources.Fusion, Brand = "Ford", Country = ECountry.USA, Consumption = 11.7m, HorsePower = 248, Length = 4871, MaxSpeed = 195, Displacements = 2000, Price = 150 });
        //    AllCards.Add(new Car() { Id = 16, Code = "B5", Name = "Gol G1", Image = Resources.Gol_G1, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 7.5m, HorsePower = 96, Length = 3810, MaxSpeed = 170, Displacements = 1781, Price = 8 });
        //    AllCards.Add(new Car() { Id = 17, Code = "B1", Name = "Gol G4", Image = Resources.Gol_G4, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 10.8m, HorsePower = 71, Length = 3931, MaxSpeed = 168, Displacements = 1000, Price = 16 });
        //    AllCards.Add(new Car() { Id = 18, Code = "A3", Name = "Hilux", Image = Resources.Hilux, Brand = "Toyota", Country = ECountry.Japan, Consumption = 9m, HorsePower = 163, Length = 5325, MaxSpeed = 180, Displacements = 2700, Price = 145 });
        //    AllCards.Add(new Car() { Id = 19, Code = "D5", Name = "Ka", Image = Resources.Ka, Brand = "Ford", Country = ECountry.USA, Consumption = 9.6m, HorsePower = 73, Length = 3836, MaxSpeed = 160, Displacements = 1000, Price = 15 });
        //    AllCards.Add(new Car() { Id = 20, Code = "A0", Name = "Kombi", Image = Resources.Kombi, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 8.4m, HorsePower = 80, Length = 4505, MaxSpeed = 130, Displacements = 1390, Price = 27 });
        //    AllCards.Add(new Car() { Id = 21, Code = "D2", Name = "L200", Image = Resources.L200, Brand = "Mitsubishi", Country = ECountry.Japan, Consumption = 13.2m, HorsePower = 190, Length = 5280, MaxSpeed = 179, Displacements = 2400, Price = 172 });
        //    AllCards.Add(new Car() { Id = 22, Code = "B9", Name = "Logan", Image = Resources.Logan, Brand = "Renault", Country = ECountry.France, Consumption = 10.2m, HorsePower = 82, Length = 4349, MaxSpeed = 164, Displacements = 1000, Price = 63 });
        //    AllCards.Add(new Car() { Id = 23, Code = "B6", Name = "Master", Image = Resources.Master, Brand = "Renault", Country = ECountry.France, Consumption = 8.1m, HorsePower = 130, Length = 5642, MaxSpeed = 145, Displacements = 2300, Price = 173 });
        //    AllCards.Add(new Car() { Id = 24, Code = "A9", Name = "Montana", Image = Resources.Montana, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 12.1m, HorsePower = 99, Length = 4514, MaxSpeed = 170, Displacements = 1400, Price = 75 });
        //    AllCards.Add(new Car() { Id = 25, Code = "A7", Name = "Omega GLS", Image = Resources.Omega_GLS, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 7.5m, HorsePower = 116, Length = 4738, MaxSpeed = 189, Displacements = 2000, Price = 8 });
        //    AllCards.Add(new Car() { Id = 26, Code = "C4", Name = "Palio Weekend", Image = Resources.Palio_Weekend, Brand = "Fiat", Country = ECountry.Italy, Consumption = 11.1m, HorsePower = 132, Length = 4310, MaxSpeed = 184, Displacements = 1700, Price = 65 });
        //    AllCards.Add(new Car() { Id = 27, Code = "D6", Name = "Polo", Image = Resources.Polo, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 13.9m, HorsePower = 128, Length = 4053, MaxSpeed = 192, Displacements = 1000, Price = 58 });
        //    AllCards.Add(new Car() { Id = 28, Code = "D9", Name = "Ranger 3.0", Image = Resources.Ranger_3_0, Brand = "Ford", Country = ECountry.USA, Consumption = 10.4m, HorsePower = 163, Length = 5143, MaxSpeed = 170, Displacements = 3000, Price = 167 });
        //    AllCards.Add(new Car() { Id = 29, Code = "D1", Name = "Renegade", Image = Resources.Renegade, Brand = "Jeep", Country = ECountry.USA, Consumption = 12.2m, HorsePower = 139, Length = 4232, MaxSpeed = 182, Displacements = 1700, Price = 70 });
        //    AllCards.Add(new Car() { Id = 30, Code = "A5", Name = "S10", Image = Resources.S10, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 8.2m, HorsePower = 206, Length = 5347, MaxSpeed = 163, Displacements = 2500, Price = 68 });
        //    AllCards.Add(new Car() { Id = 31, Code = "B7", Name = "Saveiro Surf", Image = Resources.Saveiro_Surf, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 11.3m, HorsePower = 99, Length = 4451, MaxSpeed = 165, Displacements = 1600, Price = 26 });
        //    AllCards.Add(new Car() { Id = 32, Code = "B0", Name = "Serie 4 428", Image = Resources.Serie_4_428, Brand = "BMW", Country = ECountry.Germany, Consumption = 12.1m, HorsePower = 245, Length = 4638, MaxSpeed = 250, Displacements = 2000, Price = 311 });
        //    AllCards.Add(new Car() { Id = 33, Code = "C9", Name = "Siena", Image = Resources.Siena, Brand = "Fiat", Country = ECountry.Italy, Consumption = 13.2m, HorsePower = 86, Length = 4115, MaxSpeed = 167, Displacements = 1400, Price = 31 });
        //    AllCards.Add(new Car() { Id = 34, Code = "D0", Name = "Spacefox", Image = Resources.Spacefox, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 9.4m, HorsePower = 104, Length = 4204, MaxSpeed = 177, Displacements = 1600, Price = 41 });
        //    AllCards.Add(new Car() { Id = 35, Code = "C6", Name = "Tiguan", Image = Resources.Tiguan, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 9.6m, HorsePower = 220, Length = 4705, MaxSpeed = 223, Displacements = 2000, Price = 225 });
        //    AllCards.Add(new Car() { Id = 36, Code = "D7", Name = "Toro", Image = Resources.Toro, Brand = "Fiat", Country = ECountry.Italy, Consumption = 11.2m, HorsePower = 139, Length = 4915, MaxSpeed = 181, Displacements = 1700, Price = 100 });
        //    AllCards.Add(new Car() { Id = 37, Code = "C8", Name = "Tucson", Image = Resources.Tucson, Brand = "Hyundai", Country = ECountry.SouthCorea, Consumption = 15.1m, HorsePower = 143, Length = 4325, MaxSpeed = 180, Displacements = 2000, Price = 155 });
        //    AllCards.Add(new Car() { Id = 38, Code = "C0", Name = "Uno", Image = Resources.Uno, Brand = "Fiat", Country = ECountry.Italy, Consumption = 8.5m, HorsePower = 57, Length = 3644, MaxSpeed = 151, Displacements = 1000, Price = 9 });
        //    AllCards.Add(new Car() { Id = 39, Code = "C5", Name = "Vectra", Image = Resources.Vectra, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 8.2m, HorsePower = 123, Length = 4495, MaxSpeed = 195, Displacements = 2198, Price = 15 });
        //    AllCards.Add(new Car() { Id = 40, Code = "D4", Name = "Zafira", Image = Resources.Zafira, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 9.4m, HorsePower = 140, Length = 4334, MaxSpeed = 181, Displacements = 2000, Price = 30 });
        //}

        private void CreateCards()
        {
            AllCards = new List<Car>();
            AllCards.Add(new Car() { Id = 1, Code = "C2", Name = "Alure 408", Image = Resources.Alure_408, Brand = "Peugeot", Country = ECountry.France, Consumption = 12.8m, HorsePower = 115, Length = 4159, MaxSpeed = 185, Displacements = 2000, Price = 83 });
            AllCards.Add(new Car() { Id = 2, Code = "A6", Name = "Amarok", Image = Resources.Amarok, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 8.4m, HorsePower = 180, Length = 5254, MaxSpeed = 179, Displacements = 2000, Price = 243 });
            AllCards.Add(new Car() { Id = 3, Code = "A2", Name = "Astra", Image = Resources.Astra, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 10.7m, HorsePower = 128, Length = 4199, MaxSpeed = 201, Displacements = 2000, Price = 29 });
            AllCards.Add(new Car() { Id = 4, Code = "C1", Name = "Bandeirantes", Image = Resources.Bandeirantes, Brand = "Toyota", Country = ECountry.Japan, Consumption = 9m, HorsePower = 96, Length = 5300, MaxSpeed = 125, Displacements = 3661, Price = 40 });
            AllCards.Add(new Car() { Id = 5, Code = "C3", Name = "C3", Image = Resources.C3, Brand = "Citroën", Country = ECountry.France, Consumption = 16.6m, HorsePower = 90, Length = 3944, MaxSpeed = 171, Displacements = 2000, Price = 62 });
            AllCards.Add(new Car() { Id = 6, Code = "B2", Name = "Celta", Image = Resources.Celta, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 12.9m, HorsePower = 78, Length = 3788, MaxSpeed = 161, Displacements = 2000, Price = 28 });
            AllCards.Add(new Car() { Id = 7, Code = "D8", Name = "Classic", Image = Resources.Classic, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 13.6m, HorsePower = 78, Length = 4152, MaxSpeed = 166, Displacements = 2000, Price = 30 });
            AllCards.Add(new Car() { Id = 8, Code = "B4", Name = "Corola", Image = Resources.Corola, Brand = "Toyota", Country = ECountry.Japan, Consumption = 13.9m, HorsePower = 177, Length = 4630, MaxSpeed = 199, Displacements = 2000, Price = 123 });
            AllCards.Add(new Car() { Id = 9, Code = "D3", Name = "Corsa Joy", Image = Resources.Corsa_Joy, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 10.9m, HorsePower = 78, Length = 3822, MaxSpeed = 166, Displacements = 2000, Price = 16 });
            AllCards.Add(new Car() { Id = 10, Code = "B3", Name = "Cruze", Image = Resources.Cruze, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 14m, HorsePower = 153, Length = 4665, MaxSpeed = 214, Displacements = 2000, Price = 120 });
            AllCards.Add(new Car() { Id = 11, Code = "A4", Name = "Ecosport", Image = Resources.Ecosport, Brand = "Ford", Country = ECountry.USA, Consumption = 8.8m, HorsePower = 107, Length = 4240, MaxSpeed = 165, Displacements = 12000598, Price = 31 });
            AllCards.Add(new Car() { Id = 12, Code = "C7", Name = "Etios", Image = Resources.Etios, Brand = "Toyota", Country = ECountry.Japan, Consumption = 9.8m, HorsePower = 107, Length = 3884, MaxSpeed = 187, Displacements = 2000, Price = 56 });
            AllCards.Add(new Car() { Id = 13, Code = "B8", Name = "Fiesta", Image = Resources.Fiesta, Brand = "Ford", Country = ECountry.USA, Consumption = 12m, HorsePower = 73, Length = 3930, MaxSpeed = 146, Displacements = 2000, Price = 19 });
            AllCards.Add(new Car() { Id = 14, Code = "A1", Name = "Fox Trend", Image = Resources.Fox_Trend, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 12.2m, HorsePower = 76, Length = 3823, MaxSpeed = 132, Displacements = 2000, Price = 54 });
            AllCards.Add(new Car() { Id = 15, Code = "A8", Name = "Fusion", Image = Resources.Fusion, Brand = "Ford", Country = ECountry.USA, Consumption = 11.7m, HorsePower = 248, Length = 4871, MaxSpeed = 195, Displacements = 2000, Price = 150 });
            AllCards.Add(new Car() { Id = 16, Code = "B5", Name = "Gol G1", Image = Resources.Gol_G1, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 7.5m, HorsePower = 96, Length = 3810, MaxSpeed = 170, Displacements = 2000, Price = 8 });
            AllCards.Add(new Car() { Id = 17, Code = "B1", Name = "Gol G4", Image = Resources.Gol_G4, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 10.8m, HorsePower = 71, Length = 3931, MaxSpeed = 168, Displacements = 2000, Price = 16 });
            AllCards.Add(new Car() { Id = 18, Code = "A3", Name = "Hilux", Image = Resources.Hilux, Brand = "Toyota", Country = ECountry.Japan, Consumption = 9m, HorsePower = 163, Length = 5325, MaxSpeed = 180, Displacements = 2000, Price = 145 });
            AllCards.Add(new Car() { Id = 19, Code = "D5", Name = "Ka", Image = Resources.Ka, Brand = "Ford", Country = ECountry.USA, Consumption = 9.6m, HorsePower = 73, Length = 3836, MaxSpeed = 160, Displacements = 2000, Price = 15 });
            AllCards.Add(new Car() { Id = 20, Code = "A0", Name = "Kombi", Image = Resources.Kombi, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 8.4m, HorsePower = 80, Length = 4505, MaxSpeed = 130, Displacements = 2000, Price = 27 });
            AllCards.Add(new Car() { Id = 21, Code = "D2", Name = "L200", Image = Resources.L200, Brand = "Mitsubishi", Country = ECountry.Japan, Consumption = 13.2m, HorsePower = 190, Length = 5280, MaxSpeed = 179, Displacements = 2000, Price = 172 });
            AllCards.Add(new Car() { Id = 22, Code = "B9", Name = "Logan", Image = Resources.Logan, Brand = "Renault", Country = ECountry.France, Consumption = 10.2m, HorsePower = 82, Length = 4349, MaxSpeed = 164, Displacements = 2000, Price = 63 });
            AllCards.Add(new Car() { Id = 23, Code = "B6", Name = "Master", Image = Resources.Master, Brand = "Renault", Country = ECountry.France, Consumption = 8.1m, HorsePower = 130, Length = 5642, MaxSpeed = 145, Displacements = 2000, Price = 173 });
            AllCards.Add(new Car() { Id = 24, Code = "A9", Name = "Montana", Image = Resources.Montana, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 12.1m, HorsePower = 99, Length = 4514, MaxSpeed = 170, Displacements = 2000, Price = 75 });
            AllCards.Add(new Car() { Id = 25, Code = "A7", Name = "Omega GLS", Image = Resources.Omega_GLS, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 7.5m, HorsePower = 116, Length = 4738, MaxSpeed = 189, Displacements = 2000, Price = 8 });
            AllCards.Add(new Car() { Id = 26, Code = "C4", Name = "Palio Weekend", Image = Resources.Palio_Weekend, Brand = "Fiat", Country = ECountry.Italy, Consumption = 11.1m, HorsePower = 132, Length = 4310, MaxSpeed = 184, Displacements = 2000, Price = 65 });
            AllCards.Add(new Car() { Id = 27, Code = "D6", Name = "Polo", Image = Resources.Polo, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 13.9m, HorsePower = 128, Length = 4053, MaxSpeed = 192, Displacements = 2000, Price = 58 });
            AllCards.Add(new Car() { Id = 28, Code = "D9", Name = "Ranger 3.0", Image = Resources.Ranger_3_0, Brand = "Ford", Country = ECountry.USA, Consumption = 10.4m, HorsePower = 163, Length = 5143, MaxSpeed = 170, Displacements = 2000, Price = 167 });
            AllCards.Add(new Car() { Id = 29, Code = "D1", Name = "Renegade", Image = Resources.Renegade, Brand = "Jeep", Country = ECountry.USA, Consumption = 12.2m, HorsePower = 139, Length = 4232, MaxSpeed = 182, Displacements = 2000, Price = 70 });
            AllCards.Add(new Car() { Id = 30, Code = "A5", Name = "S10", Image = Resources.S10, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 8.2m, HorsePower = 206, Length = 5347, MaxSpeed = 163, Displacements = 2000, Price = 68 });
            AllCards.Add(new Car() { Id = 31, Code = "B7", Name = "Saveiro Surf", Image = Resources.Saveiro_Surf, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 11.3m, HorsePower = 99, Length = 4451, MaxSpeed = 165, Displacements = 2000, Price = 26 });
            AllCards.Add(new Car() { Id = 32, Code = "B0", Name = "Serie 4 428", Image = Resources.Serie_4_428, Brand = "BMW", Country = ECountry.Germany, Consumption = 12.1m, HorsePower = 245, Length = 4638, MaxSpeed = 250, Displacements = 2000, Price = 311 });
            AllCards.Add(new Car() { Id = 33, Code = "C9", Name = "Siena", Image = Resources.Siena, Brand = "Fiat", Country = ECountry.Italy, Consumption = 13.2m, HorsePower = 86, Length = 4115, MaxSpeed = 167, Displacements = 2000, Price = 31 });
            AllCards.Add(new Car() { Id = 34, Code = "D0", Name = "Spacefox", Image = Resources.Spacefox, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 9.4m, HorsePower = 104, Length = 4204, MaxSpeed = 177, Displacements = 2000, Price = 41 });
            AllCards.Add(new Car() { Id = 35, Code = "C6", Name = "Tiguan", Image = Resources.Tiguan, Brand = "Volkswagen", Country = ECountry.Germany, Consumption = 9.6m, HorsePower = 220, Length = 4705, MaxSpeed = 223, Displacements = 2000, Price = 225 });
            AllCards.Add(new Car() { Id = 36, Code = "D7", Name = "Toro", Image = Resources.Toro, Brand = "Fiat", Country = ECountry.Italy, Consumption = 11.2m, HorsePower = 139, Length = 4915, MaxSpeed = 181, Displacements = 2000, Price = 100 });
            AllCards.Add(new Car() { Id = 37, Code = "C8", Name = "Tucson", Image = Resources.Tucson, Brand = "Hyundai", Country = ECountry.SouthCorea, Consumption = 15.1m, HorsePower = 143, Length = 4325, MaxSpeed = 180, Displacements = 2000, Price = 155 });
            AllCards.Add(new Car() { Id = 38, Code = "C0", Name = "Uno", Image = Resources.Uno, Brand = "Fiat", Country = ECountry.Italy, Consumption = 8.5m, HorsePower = 57, Length = 3644, MaxSpeed = 151, Displacements = 2000, Price = 9 });
            AllCards.Add(new Car() { Id = 39, Code = "C5", Name = "Vectra", Image = Resources.Vectra, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 8.2m, HorsePower = 123, Length = 4495, MaxSpeed = 195, Displacements = 2000, Price = 15 });
            AllCards.Add(new Car() { Id = 40, Code = "D4", Name = "Zafira", Image = Resources.Zafira, Brand = "Chevrolet", Country = ECountry.USA, Consumption = 9.4m, HorsePower = 140, Length = 4334, MaxSpeed = 181, Displacements = 2000, Price = 30 });
        }

        private void ShuffleCards()
        {
            Player1Cards = new List<Car>();
            Player2Cards = new List<Car>();
            Random random = new Random();
            var value = 0;

            for (int i = 1; i <= 20; i++)
            {
                do
                    value = random.Next(40);
                while(!AllCards.Any(obj => obj.Id == value));
                Player1Cards.Add((Car)AllCards.Where(obj => obj.Id == value).FirstOrDefault());
                AllCards.Remove((Car)AllCards.Where(obj => obj.Id == value).FirstOrDefault());
            }
            Player2Cards = AllCards;
        }

        private void TurnCard(EPlayer player)
        {
            if (player == EPlayer.Player1)
            {
                Player1IsVisible = !Player1IsVisible;
                RefreshCard(EPlayer.Player1);
            }

            if (player == EPlayer.Player2)
            {
                Player2IsVisible = !Player2IsVisible;
                RefreshCard(EPlayer.Player2);
            }
        }

        private void ResetThumbs(EPlayer player)
        {
            if (player == EPlayer.Player1)
                picThumb21Player1.Visible =
                picThumb22Player1.Visible =
                picThumb23Player1.Visible =
                picThumb24Player1.Visible =
                picThumb25Player1.Visible =
                picThumb26Player1.Visible =
                picThumb27Player1.Visible =
                picThumb28Player1.Visible =
                picThumb29Player1.Visible =
                picThumb30Player1.Visible =
                picThumb31Player1.Visible =
                picThumb32Player1.Visible =
                picThumb33Player1.Visible =
                picThumb34Player1.Visible =
                picThumb35Player1.Visible =
                picThumb36Player1.Visible =
                picThumb37Player1.Visible =
                picThumb38Player1.Visible =
                picThumb39Player1.Visible =
                picThumb40Player1.Visible =
                    false;

            if (player == EPlayer.Player2)
                picThumb21Player2.Visible =
                picThumb22Player2.Visible =
                picThumb23Player2.Visible =
                picThumb24Player2.Visible =
                picThumb25Player2.Visible =
                picThumb26Player2.Visible =
                picThumb27Player2.Visible =
                picThumb28Player2.Visible =
                picThumb29Player2.Visible =
                picThumb30Player2.Visible =
                picThumb31Player2.Visible =
                picThumb32Player2.Visible =
                picThumb33Player2.Visible =
                picThumb34Player2.Visible =
                picThumb35Player2.Visible =
                picThumb36Player2.Visible =
                picThumb37Player2.Visible =
                picThumb38Player2.Visible =
                picThumb39Player2.Visible =
                picThumb40Player2.Visible =
                    false;
        }

        private void RefreshCard(EPlayer player)
        {
            if (player == EPlayer.Player1)
            {
                lblCarNamePlayer1.Visible = Player1IsVisible;
                lblCarBrandPlayer1.Visible = Player1IsVisible;
                lblCodeCardPlayer1.Visible = Player1IsVisible;
                lblConsumptionPlayer1.Visible = lblConsumptionPlayer1Value.Visible = Player1IsVisible;
                lblHorsePowerPlayer1.Visible = lblHorsePowerPlayer1Value.Visible = Player1IsVisible;
                lblLengthPlayer1.Visible = lblLengthPlayer1Value.Visible = Player1IsVisible;
                lblDisplacementsPlayer1.Visible = lblDisplacementsPlayer1Value.Visible = Player1IsVisible;
                lblMaxSpeedPlayer1.Visible = lblMaxSpeedPlayer1Value.Visible = Player1IsVisible;
                lblPricePlayer1.Visible = lblPricePlayer1Value.Visible = Player1IsVisible;

                picCountryPlayer1.Visible = Player1IsVisible;
                picCarPlayer1.Visible = Player1IsVisible;
                picCardPlayer1.Image = Player1IsVisible ? Resources.Front : Resources.Back;
            }

            if (player == EPlayer.Player2)
            {
                lblCarNamePlayer2.Visible = Player2IsVisible;
                lblCarBrandPlayer2.Visible = Player2IsVisible;
                lblCodeCardPlayer2.Visible = Player2IsVisible;
                lblConsumptionPlayer2.Visible = lblConsumptionPlayer2Value.Visible = Player2IsVisible;
                lblHorsePowerPlayer2.Visible = lblHorsePowerPlayer2Value.Visible = Player2IsVisible;
                lblLengthPlayer2.Visible = lblLengthPlayer2Value.Visible = Player2IsVisible;
                lblDisplacementsPlayer2.Visible = lblDisplacementsPlayer2Value.Visible = Player2IsVisible;
                lblMaxSpeedPlayer2.Visible = lblMaxSpeedPlayer2Value.Visible = Player2IsVisible;
                lblPricePlayer2.Visible = lblPricePlayer2Value.Visible = Player2IsVisible;

                picCountryPlayer2.Visible = Player2IsVisible;
                picCarPlayer2.Visible = Player2IsVisible;
                picCardPlayer2.Image = Player2IsVisible ? Resources.Front : Resources.Back;
            }
        }

        public void Compare(ECategory category)
        {
            if (CurrentPlayer == EPlayer.Player2 )
                MessageBox.Show("Oponente escolheu " + category);

            TurnCard(EPlayer.Player2);
            var winner = EPlayer.Tied;
            var player1CardActive = Player1Cards.FirstOrDefault();
            var player2CardActive = Player2Cards.FirstOrDefault();
            Player1Cards.Remove(Player1Cards.FirstOrDefault());
            Player2Cards.Remove(Player2Cards.FirstOrDefault());
            winner = DetermineWinner(category, player1CardActive, player2CardActive);
            CurrentWinner = winner;
            CurrentPlayer = CurrentWinner == EPlayer.Tied 
                ? CurrentPlayer == EPlayer.Player1 
                    ? EPlayer.Player2 
                    : EPlayer.Player1 
                : CurrentWinner;
            AddCardsToWinner(winner, player1CardActive, player2CardActive);
            SetLabelsColors(category, winner);
            Waiting();
            RefreshActiveCards();
            RefreshThumbs();
            RefreshTiedPannel();
            ClearLabels();
            TurnCard(EPlayer.Player2);
            StartRound();
        }

        private void CheckTied(EPlayer winner)
        {
            if (winner == EPlayer.Tied)
            {
                
            }
        }

        private void AddCardsToWinner(EPlayer winner, Car player1CardActive, Car player2CardActive)
        {
            if (EPlayer.Player1 == winner)
            {
                Player1Cards.Add(player1CardActive);
                Player1Cards.Add(player2CardActive);
                Player1Cards.AddRange(TiedCards);
                TiedCards = new List<Car>();
            }

            if (EPlayer.Player2 == winner)
            {
                Player2Cards.Add(player2CardActive);
                Player2Cards.Add(player1CardActive);
                Player2Cards.AddRange(TiedCards);
                TiedCards = new List<Car>();
            }

            if (EPlayer.Tied == winner)
            {
                TiedCards.Add(player1CardActive);
                TiedCards.Add(player2CardActive);
            }
        }

        private void RefreshTiedPannel()
        {
            var isVisible = TiedCards.Count > 0;
            lblTiedCards.Visible = isVisible;
            lblTiedCardsComplement.Visible = isVisible;
            pnlTiedCards.Visible = isVisible;
            lblTiedCards.Text = TiedCards.Count().ToString();
        }

        private static EPlayer DetermineWinner(ECategory category, Car player1CardActive, Car player2CardActive)
        {
            var winner = EPlayer.Tied;
            switch (category)
            {
                case ECategory.Consumption:
                    winner = player1CardActive.Consumption == player2CardActive.Consumption
                        ? EPlayer.Tied
                        : player1CardActive.Consumption > player2CardActive.Consumption
                            ? EPlayer.Player1
                            : EPlayer.Player2;
                    break;

                case ECategory.MaxSpeed:
                    winner = player1CardActive.MaxSpeed == player2CardActive.MaxSpeed
                        ? EPlayer.Tied
                        : player1CardActive.MaxSpeed > player2CardActive.MaxSpeed
                            ? EPlayer.Player1
                            : EPlayer.Player2;
                    break;

                case ECategory.Length:
                    winner = player1CardActive.Length == player2CardActive.Length
                        ? EPlayer.Tied
                        : player1CardActive.Length > player2CardActive.Length
                            ? EPlayer.Player1
                            : EPlayer.Player2;
                    break;

                case ECategory.HorsePower:
                    winner = player1CardActive.HorsePower == player2CardActive.HorsePower
                        ? EPlayer.Tied
                        : player1CardActive.HorsePower > player2CardActive.HorsePower
                            ? EPlayer.Player1
                            : EPlayer.Player2;
                    break;

                case ECategory.Displacements:
                    winner = player1CardActive.Displacements == player2CardActive.Displacements
                        ? EPlayer.Tied
                        : player1CardActive.Displacements > player2CardActive.Displacements
                            ? EPlayer.Player1
                            : EPlayer.Player2;
                    break;

                case ECategory.Price:
                    winner = player1CardActive.Price == player2CardActive.Price
                        ? EPlayer.Tied
                        : player1CardActive.Price < player2CardActive.Price
                            ? EPlayer.Player1
                            : EPlayer.Player2;
                    break;
            }

            return winner;
        }

        private void SetLabelsColors(ECategory category, EPlayer winner)
        {
            switch (category)
            {
                case ECategory.Consumption:
                    lblConsumptionPlayer1.BackColor = winner == EPlayer.Tied 
                        ? Color.Yellow
                        : winner == EPlayer.Player1
                            ? Color.Green
                            : Color.Red;

                    lblConsumptionPlayer2.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player2
                            ? Color.Green
                            : Color.Red;
                    break;

                case ECategory.MaxSpeed:
                    lblMaxSpeedPlayer1.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player1
                            ? Color.Green
                            : Color.Red;

                    lblMaxSpeedPlayer2.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player2
                            ? Color.Green
                            : Color.Red;
                    break;

                case ECategory.Length:
                    lblLengthPlayer1.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player1
                            ? Color.Green
                            : Color.Red;

                    lblLengthPlayer2.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player2
                            ? Color.Green
                            : Color.Red;
                    break;

                case ECategory.HorsePower:
                    lblHorsePowerPlayer1.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player1
                            ? Color.Green
                            : Color.Red;

                    lblHorsePowerPlayer2.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player2
                            ? Color.Green
                            : Color.Red;
                    break;

                case ECategory.Displacements:
                    lblDisplacementsPlayer1.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player1
                            ? Color.Green
                            : Color.Red;

                    lblDisplacementsPlayer2.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player2
                            ? Color.Green
                            : Color.Red;
                    break;

                case ECategory.Price:
                    lblPricePlayer1.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player1
                            ? Color.Green
                            : Color.Red;

                    lblPricePlayer2.BackColor = winner == EPlayer.Tied
                        ? Color.Yellow
                        : winner == EPlayer.Player2
                            ? Color.Green
                            : Color.Red;
                    break;
            }
        }

        private void StartRound()
        {
            if (CurrentPlayer == EPlayer.Player1)
                return;

            if (CurrentPlayer == EPlayer.Player2)
            {
                CommandCPU();
                return;
            }

            return;
        }

        private void Waiting()
        {
            Thread.Sleep(1000);
            MessageBox.Show("Fim da Rodada");
            Thread.Sleep(1000);
        }

        private void WaitingCPU()
        {
            Thread.Sleep(1000);
        }

        private void InitializeGame()
        {
            TurnCard(EPlayer.Player1);
            RefreshActiveCards();
            lblPlayer1.Text = txtName.Text;
            txtName.Enabled = false;
            btnStart.Enabled = false;
            ShuffleStartPlayer();
            MessageBox.Show(CurrentPlayer + " Começa!");
            StartRound();
        }

        private void ShuffleStartPlayer()
        {
            CurrentPlayer = EPlayer.Tied;
            do
            {
                Array values = Enum.GetValues(typeof(EPlayer));
                Random random = new Random();
                CurrentPlayer = (EPlayer)values.GetValue(random.Next(values.Length));
            }
            while (CurrentPlayer == EPlayer.Tied);
        }

        private void RefreshActiveCards()
        {
            SetCard(Player1Cards.FirstOrDefault(), EPlayer.Player1);
            SetCard(Player2Cards.FirstOrDefault(), EPlayer.Player2);
        }

        private void RefreshThumbs()
        {
            lblCountPlayer1.Text = Player1Cards.Count.ToString();
            lblCountPlayer2.Text = Player2Cards.Count.ToString();
            picThumb1Player1.Visible = Player1Cards.Count >= 1;
            picThumb2Player1.Visible = Player1Cards.Count >= 2;
            picThumb3Player1.Visible = Player1Cards.Count >= 3;
            picThumb4Player1.Visible = Player1Cards.Count >= 4;
            picThumb5Player1.Visible = Player1Cards.Count >= 5;
            picThumb6Player1.Visible = Player1Cards.Count >= 6;
            picThumb7Player1.Visible = Player1Cards.Count >= 7;
            picThumb8Player1.Visible = Player1Cards.Count >= 8;
            picThumb9Player1.Visible = Player1Cards.Count >= 9;
            picThumb10Player1.Visible = Player1Cards.Count >= 10;
            picThumb11Player1.Visible = Player1Cards.Count >= 11;
            picThumb12Player1.Visible = Player1Cards.Count >= 12;
            picThumb13Player1.Visible = Player1Cards.Count >= 13;
            picThumb14Player1.Visible = Player1Cards.Count >= 14;
            picThumb15Player1.Visible = Player1Cards.Count >= 15;
            picThumb16Player1.Visible = Player1Cards.Count >= 16;
            picThumb17Player1.Visible = Player1Cards.Count >= 17;
            picThumb18Player1.Visible = Player1Cards.Count >= 18;
            picThumb19Player1.Visible = Player1Cards.Count >= 19;
            picThumb20Player1.Visible = Player1Cards.Count >= 20;
            picThumb21Player1.Visible = Player1Cards.Count >= 21;
            picThumb22Player1.Visible = Player1Cards.Count >= 22;
            picThumb23Player1.Visible = Player1Cards.Count >= 23;
            picThumb24Player1.Visible = Player1Cards.Count >= 24;
            picThumb25Player1.Visible = Player1Cards.Count >= 25;
            picThumb26Player1.Visible = Player1Cards.Count >= 26;
            picThumb27Player1.Visible = Player1Cards.Count >= 27;
            picThumb28Player1.Visible = Player1Cards.Count >= 28;
            picThumb29Player1.Visible = Player1Cards.Count >= 29;
            picThumb30Player1.Visible = Player1Cards.Count >= 30;
            picThumb31Player1.Visible = Player1Cards.Count >= 31;
            picThumb32Player1.Visible = Player1Cards.Count >= 32;
            picThumb33Player1.Visible = Player1Cards.Count >= 33;
            picThumb34Player1.Visible = Player1Cards.Count >= 34;
            picThumb35Player1.Visible = Player1Cards.Count >= 35;
            picThumb36Player1.Visible = Player1Cards.Count >= 36;
            picThumb37Player1.Visible = Player1Cards.Count >= 37;
            picThumb38Player1.Visible = Player1Cards.Count >= 38;
            picThumb39Player1.Visible = Player1Cards.Count >= 39;
            picThumb40Player1.Visible = Player1Cards.Count >= 40;
            picThumb1Player2.Visible = Player2Cards.Count >= 1;
            picThumb2Player2.Visible = Player2Cards.Count >= 2;
            picThumb3Player2.Visible = Player2Cards.Count >= 3;
            picThumb4Player2.Visible = Player2Cards.Count >= 4;
            picThumb5Player2.Visible = Player2Cards.Count >= 5;
            picThumb6Player2.Visible = Player2Cards.Count >= 6;
            picThumb7Player2.Visible = Player2Cards.Count >= 7;
            picThumb8Player2.Visible = Player2Cards.Count >= 8;
            picThumb9Player2.Visible = Player2Cards.Count >= 9;
            picThumb10Player2.Visible = Player2Cards.Count >= 10;
            picThumb11Player2.Visible = Player2Cards.Count >= 11;
            picThumb12Player2.Visible = Player2Cards.Count >= 12;
            picThumb13Player2.Visible = Player2Cards.Count >= 13;
            picThumb14Player2.Visible = Player2Cards.Count >= 14;
            picThumb15Player2.Visible = Player2Cards.Count >= 15;
            picThumb16Player2.Visible = Player2Cards.Count >= 16;
            picThumb17Player2.Visible = Player2Cards.Count >= 17;
            picThumb18Player2.Visible = Player2Cards.Count >= 18;
            picThumb19Player2.Visible = Player2Cards.Count >= 19;
            picThumb20Player2.Visible = Player2Cards.Count >= 20;
            picThumb21Player2.Visible = Player2Cards.Count >= 21;
            picThumb22Player2.Visible = Player2Cards.Count >= 22;
            picThumb23Player2.Visible = Player2Cards.Count >= 23;
            picThumb24Player2.Visible = Player2Cards.Count >= 24;
            picThumb25Player2.Visible = Player2Cards.Count >= 25;
            picThumb26Player2.Visible = Player2Cards.Count >= 26;
            picThumb27Player2.Visible = Player2Cards.Count >= 27;
            picThumb28Player2.Visible = Player2Cards.Count >= 28;
            picThumb29Player2.Visible = Player2Cards.Count >= 29;
            picThumb30Player2.Visible = Player2Cards.Count >= 30;
            picThumb31Player2.Visible = Player2Cards.Count >= 31;
            picThumb32Player2.Visible = Player2Cards.Count >= 32;
            picThumb33Player2.Visible = Player2Cards.Count >= 33;
            picThumb34Player2.Visible = Player2Cards.Count >= 34;
            picThumb35Player2.Visible = Player2Cards.Count >= 35;
            picThumb36Player2.Visible = Player2Cards.Count >= 36;
            picThumb37Player2.Visible = Player2Cards.Count >= 37;
            picThumb38Player2.Visible = Player2Cards.Count >= 38;
            picThumb39Player2.Visible = Player2Cards.Count >= 39;
            picThumb40Player2.Visible = Player2Cards.Count >= 40;
        }

        private void SetCard(Car car, EPlayer player)
        {
            if (player == EPlayer.Player1)
            {
                lblCarNamePlayer1.Text = car.Name;
                lblCarBrandPlayer1.Text = car.Brand;
                lblCodeCardPlayer1.Text = car.Code;
                picCarPlayer1.Image = car.Image;
                picCarPlayer1.SizeMode = PictureBoxSizeMode.StretchImage;

                lblConsumptionPlayer1Value.Text = car.Consumption.ToString();
                lblMaxSpeedPlayer1Value.Text = car.MaxSpeed.ToString();
                lblLengthPlayer1Value.Text = car.Length.ToString();
                lblHorsePowerPlayer1Value.Text = car.HorsePower.ToString();
                lblDisplacementsPlayer1Value.Text = car.Displacements.ToString();
                lblPricePlayer1Value.Text = car.Price.ToString();
            }

            if (player == EPlayer.Player2)
            {
                lblCarNamePlayer2.Text = car.Name;
                lblCarBrandPlayer2.Text = car.Brand;
                lblCodeCardPlayer2.Text = car.Code;
                picCarPlayer2.Image = car.Image;
                picCarPlayer2.SizeMode = PictureBoxSizeMode.StretchImage;

                lblConsumptionPlayer2Value.Text = car.Consumption.ToString();
                lblMaxSpeedPlayer2Value.Text = car.MaxSpeed.ToString();
                lblLengthPlayer2Value.Text = car.Length.ToString();
                lblHorsePowerPlayer2Value.Text = car.HorsePower.ToString();
                lblDisplacementsPlayer2Value.Text = car.Displacements.ToString();
                lblPricePlayer2Value.Text = car.Price.ToString();
            }
        }

        private void ClearLabels()
        {
            lblConsumptionPlayer1.BackColor = Color.White;
            lblMaxSpeedPlayer1.BackColor = Color.White;
            lblLengthPlayer1.BackColor = Color.White;
            lblHorsePowerPlayer1.BackColor = Color.White;
            lblDisplacementsPlayer1.BackColor = Color.White;
            lblPricePlayer1.BackColor = Color.White;

            lblConsumptionPlayer2.BackColor = Color.White;
            lblMaxSpeedPlayer2.BackColor = Color.White;
            lblLengthPlayer2.BackColor = Color.White;
            lblHorsePowerPlayer2.BackColor = Color.White;
            lblDisplacementsPlayer2.BackColor = Color.White;
            lblPricePlayer2.BackColor = Color.White;
        }

        private void CommandCPU()
        {
            Array values = Enum.GetValues(typeof(ECategory));
            Random random = new Random();
            ECategory randomCategory = (ECategory)values.GetValue(random.Next(values.Length));
            WaitingCPU();
            Compare(randomCategory);
        }
        #endregion
    }
}

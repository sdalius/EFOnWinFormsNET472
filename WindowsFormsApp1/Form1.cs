using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp1.Models;
using WindowsFormsApp1.Repositories;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly PetsRepository _petsRepository;
        public Form1(PetsRepository petsRepository)
        {
            InitializeComponent();
            _petsRepository = petsRepository;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var list = await _petsRepository.Read();

            foreach(var item in list)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("We read it, now lets just maybe try updating it?");

            var firstItemInTheList = list.FirstOrDefault();

            firstItemInTheList.Name = "Naujas Name";


            await _petsRepository.UpdateAsync(new List<Pets> { firstItemInTheList });

            Console.WriteLine("Update Worked?");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await _petsRepository.CreateAsync();

            Console.WriteLine("Created Successfully!@!@!@!@!");
        }
    }
}

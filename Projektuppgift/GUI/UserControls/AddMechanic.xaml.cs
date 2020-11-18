﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Logic.Entities;
using System.IO;
using Newtonsoft.Json;
using static Logic.Services.StaticLists;
using GUI.UserControls;

namespace Projektuppgift.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlAddMechanic.xaml
    /// </summary>
    public partial class AddMechanic : UserControl
    {
        private const string AddMessage = "You have added a mechanic!";
        public AddMechanic()
        {
            InitializeComponent();
            //Hämta mekaniker från JSON.           
            //string jsonFromFile;
            //using (var reader = new StreamReader(mechpath))
            //{
            //    jsonFromFile = reader.ReadToEnd();
            //}
            //var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
            
            
            

        }

        public async void AddMechanicButton_Click(object sender, RoutedEventArgs e)
        {


            string firstName = this.tbFirstName.Text;
            string surName = this.tbSurName.Text;
            string dateOfBirth = this.tbDateOfBirth.Text;
            string dateOfEmployment = this.tbDateOfEmployment.Text;
            string employmentEnds = this.tbEmploymentEnds.Text;
            string EnginesAreChecked = ((bool)cbEnginesYes.IsChecked) ? "Yes" : "No";
            string TiresAreChecked = ((bool)cbTiresYes.IsChecked) ? "Yes" : "No";
            string BrakesAreChecked = ((bool)cbBrakesYes.IsChecked) ? "Yes" : "No";
            string WindshieldsAreChecked = ((bool)cbWindshieldsYes.IsChecked) ? "Yes" : "No";
            string VehicleBodyIsChecked = ((bool)cbVehicleBodyYes.IsChecked) ? "Yes" : "No";

            //string firstName = this.tbFirstName.Text;
            //string surName = this.tbSurName.Text;
            //string dateOfBirth = this.tbDateOfBirth.Text;
            //string dateOfEmployment = this.tbDateOfEmployment.Text;
            //string employmentEnds = this.tbEmploymentEnds.Text;
            //string EnginesAreChecked = ((bool)cbEnginesYes.IsChecked) ? "CanFixEngines" : "";
            //string TiresAreChecked = ((bool)cbTiresYes.IsChecked) ? "CanFixTires" : "";
            //string BrakesAreChecked = ((bool)cbBrakesYes.IsChecked) ? "CanFixBrakes" : "";
            //string WindshieldsAreChecked = ((bool)cbWindshieldsYes.IsChecked) ? "CanFixWindshields" : "";
            //string VehicleBodyIsChecked = ((bool)cbVehicleBodyYes.IsChecked) ? "CanFixVehicleBody" : "";



            Mechanic mechanic = new Mechanic
            {
                FirstName = firstName,
                SurName = surName,
                DateOfBirth = dateOfBirth,
                DateOfEmployment = dateOfEmployment,
                EndDate = employmentEnds,
                MechID = Guid.NewGuid(),
                CanFixEngines = EnginesAreChecked,
                CanFixTires = TiresAreChecked,
                CanFixBrakes = BrakesAreChecked,
                CanFixWindshields = WindshieldsAreChecked,
                CanFixVehicleBody = VehicleBodyIsChecked,
                ErrandIDs = Guid.NewGuid(),
                ActiveErrands = 0

            };
       
            //READ
            if (mechanics.Count >= 1)
            {
                string jsonFromFile;
                using (var reader = new StreamReader(mechpath))
                {
                    jsonFromFile = reader.ReadToEnd();
                }
                var readFromJson = JsonConvert.DeserializeObject<List<Mechanic>>(jsonFromFile);
                mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                using (var writer = new StreamWriter(mechpath)) 
                {   
                await writer.WriteAsync(jsonToWrite);
                
                }
            }
            //ADD
            else
            {
                mechanics.Add(mechanic);
                var jsonToWrite = JsonConvert.SerializeObject(mechanics, Formatting.Indented);
                var fs = File.OpenWrite(mechpath);
                using (var writer = new StreamWriter(fs))
                {
                   await writer.WriteAsync(jsonToWrite);

                }
            }
            AddMechView.Children.Clear();
            AddMechView.Children.Add(new AddMechanic());

            MessageBox.Show(AddMessage);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            AddMechView.Children.Clear();
            AddMechView.Children.Add(new MechanicHome());

        }
    }
}     

   


            //if (File.Exists(mechpath))
            //{
            //    File.OpenRead(mechpath);              
            //    var readText = File.ReadAllText(mechpath);
            //    if (readText.Length > 0)
            //    {
            //        JsonConvert.DeserializeObject(mechpath);
            //        mechanics.Add(mechanic);
            //        File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            //    }
            //}
            //else
            //{
            //    File.Create(mechpath);
            //    mechanics.Add(mechanic);
            //    File.WriteAllText(mechpath, JsonConvert.SerializeObject(mechanics));
            //}

            //AddMechanicService.SaveMechanic(AddMechanicService.mechanics);

            
 
            //if (File.Exists(AddMechanicService.mechpath) && AddMechanicService.mechanics.Count > 1)
            //{
            //    var jsonString = File.ReadAllText(AddMechanicService.mechpath);
            //    var list = JsonConvert.DeserializeObject<List<Mechanic>>(jsonString);
            //    list.Add(mechanic);             
            //    File.WriteAllText(AddMechanicService.mechpath, JsonConvert.SerializeObject(list, Formatting.Indented));

            //}
        
    


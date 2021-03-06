﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Subclasses;

namespace Garage
{
    public class Garage<T> : IEnumerable<T> where T : Vehicles
    {
        private List<T> maxvehicle;
        private int maxcapacity;
        private int count;

        Vehicles TestVeh = new Vehicles();
        //Car NEWCar = new Car();

        public int MaxCapacity { get { return maxcapacity; } }
        public int Count { get { return count; } set { count = value; } }
        #region CREATING GARAGE WITH CAPACITY USER NEEDS.ASSINGNING THE VALUE GIVEN BY USER TO THE MAXCAPACITY AND INSTANTIATING LIST
        public Garage(int maxCapSetted)
        {
            maxvehicle = new List<T>();
            maxcapacity = maxCapSetted;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-------------------------------------------------------\n " +
                                "  GARAGE CREATED WITH A CAPACITY OF :" + maxcapacity + " VEHICLES" +
                               "\n-------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        #endregion
        #region ADD AND REMOVE VEHICLES IN THE GARAGE
        public Garage()
        {
        }
        public void AddtoList(T input)
        {
            if (maxcapacity - maxvehicle.Count <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------\n  SORRY  GARAGE  FULL\n------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            if (count < maxcapacity)
            {
                maxvehicle.Add(input);
                count++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-------------------------------------\n" +
                "          VEHICLE PARKED\n" +
                "-------------------------------------\n");
            Console.WriteLine("-------------------------------------\nYOUR GARAGE CAN HAVE :" + (maxcapacity - maxvehicle.Count) +
                " MORE VEHICLES\n-------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public void RemoveVeh(T input)
        {
            string Regnotodel1 = input.Name;
            var match = maxvehicle.Where(stc => stc.Name.Contains(Regnotodel1));
            if (maxvehicle.Count == 0)
            {
                Console.WriteLine("NO MORE VEHICLES TO REMOVE");
                return;
            }

            else if (match != null && match.Any())
            /*(count <= maxcapacity)*/
            {
                string Regnotodel = input.Name;
                maxvehicle.RemoveAll(x => x.Name.StartsWith(Regnotodel));
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("-----------------------------------\n" +
                    "YOU HAVE UNPARKED A VEHICLE  :" + Regnotodel +
                    "\n-----------------------------------");
                count--;
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------------------\n"+
                    "NO VEHICLE WITH THAT REG.NO. FOUND.");
                Console.ResetColor();
            }
            Console.WriteLine("-----------------------------------\n" +
                "YOUR GARAGE CAN HAVE :" + (maxcapacity - count) + " VEHICLES"+

                "\n-----------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        #endregion
        #region DISPLAY ALL VEHICLES
        public void AllVehicles()
        {

            if (maxvehicle.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO VEHICLES IN THE GARAGE");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                foreach (var veh in maxvehicle)
                    Console.WriteLine(TestVeh.GarageInfo());
                Console.WriteLine("THE NUMBER OF VEHICLES IN THE GARAGE IS :" + maxvehicle.Count.ToString());
            }
            Console.ReadLine();
        }
        #endregion
        #region DISPLAY COUNT OF ALL VEHICLES
        public void VEHICLECOUNTS()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            int ccount = maxvehicle.Where(x => x.VehTYPE.Contains("CAR")).Count();
            Console.WriteLine("THE NUMBER OF CARS IN THE GARAGE IS:" + ccount);
            
            int ccount2 = maxvehicle.Where(x => x.VehTYPE.Contains("BUS")).Count();
            Console.WriteLine("THE NUMBER OF BUS IN THE GARAGE IS:" + ccount2);

            int ccount1 = maxvehicle.Where(x => x.VehTYPE.Contains("MOTORCYCLE")).Count();
            Console.WriteLine("THE NUMBER OF MOTORCYCLE IN THE GARAGE IS:" + ccount1);

            int ccount4 = maxvehicle.Where(x => x.VehTYPE.Contains("BOAT")).Count();
            Console.WriteLine("THE NUMBER OF BOAT IN THE GARAGE IS:" + ccount4);

            int ccount3 = maxvehicle.Where(x => x.VehTYPE.Contains("AIRPLANE")).Count();
            Console.WriteLine("THE NUMBER OF AIRPLANE IN THE GARAGE IS:" + ccount3);

            

            Console.WriteLine("-----------------------------------------------\n" +
                "THE TOTAL NO. OF VEHICLES IN YOUR GARAGE IS :" + maxvehicle.Count.ToString() +
                "\n-----------------------------------------------");
            Console.WriteLine("-----------------------------------------------------\n" +
            "THE TOTAL CAPACITY OF VEHICLES IN YOUR GARAGE IS :" + maxcapacity +
            "\n-----------------------------------------------------");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

        }
        #endregion
        #region Ienumerable getenumarator methods to loop in the list
        IEnumerator IEnumerable.GetEnumerator() { throw new NotImplementedException(); }
        public IEnumerator<T> GetEnumerator() { for (int i = 0; i < count; i++) { yield return maxvehicle[i]; } }
        #endregion
        #region CLEAR THE LIST FULLY DELETING THE LIST
        public void Clearall()
        {
            //maxcapacity = 0;
            //maxvehicle.Clear();
        }
        #endregion
        #region SEARCH FOR A VEHICLE
        public void SearchRegNo(T tsearch)
        {
            string search = tsearch.FuelType;
            var match = maxvehicle.Where(stc => stc.FuelType.Contains(search));
            int COUNT = 0;
            if (maxvehicle.Count == 0)
            {
                Console.WriteLine("NO  VEHICLES TO SEARCH");
                Console.ReadLine();
                return;
            }

            if (match != null && match.Any())

            {
                foreach (var item in match)
                {
                      COUNT++;
                }
                Console.WriteLine("THE NUMBER OF VEHICLES RUNNING WITH FUEL TYPE " + search + " IS  " + COUNT);
                Console.ReadLine();
           }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO VEHICLE FOUND WITH THE SEARCH CRITERIA :(");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }

        }
        #endregion

        public void SearchbyseatNo(T seatsearch)
        {
            int search = seatsearch.NoOfSeats;
            var match = maxvehicle.Where(stc => stc.NoOfSeats.Equals(search));
            int COUNT = 0;
            if (maxvehicle.Count == 0)
            { 
           
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NO VEHICLES IN THE GARAGE");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
               

                return;
            }

            if (match != null && match.Any())

            {
                foreach (var item in match)
                {
                    COUNT++;
                }
                Console.WriteLine("THE NUMBER OF VEHICLES WITH NO OF SEATS :: " + seatsearch.NoOfSeats + " :: IS  " + COUNT);
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NO VEHICLE FOUND WITH THE SEARCH CRITERIA :(");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }

          }
        }

}




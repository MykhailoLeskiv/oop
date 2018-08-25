using System;

namespace Lab_8_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Building _building = new Building();
            //if (_building.SignUp)
            {
                Console.Write("\nHello, security!\n");
                int choice = 0;
                while (choice != 7)
                {
                    Console.Write("\n1. Inizialize building\n2. Change temperature\n3. Move\n4. Replan room\n5. Inizialize from file\n6. ToString\n7. Exit\n");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Write("Enter number of floors: ");
                                _building.Inizialize(Convert.ToInt32(Console.ReadLine()));
                                break;
                            }
                        case 2:
                            {
                                if (Building.CountF != 0)
                                {
                                    int thatroom, thatfloor, thatsensor;
                                    Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                    thatfloor = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                    thatroom = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter necessary sensor ( " + _building._floor[thatfloor - 1]._room[thatroom - 1].TempDevQuantity + " ): ");
                                    thatsensor = Convert.ToInt32(Console.ReadLine());
                                    _building._floor[thatfloor - 1]._room[thatroom - 1]._sensor._temperature[thatsensor - 1].ChangeTemp();
                                }
                                else Console.Write("The building is free :)\n");
                                break;
                            }
                        case 3:
                            {
                                if (Building.CountF != 0)
                                {
                                    int thatroom, thatfloor, thatsensor;
                                    Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                    thatfloor = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                    thatroom = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Enter necessary sensor ( " + _building._floor[thatfloor - 1]._room[thatroom - 1].MovDevQuantity + " ): ");
                                    thatsensor = Convert.ToInt32(Console.ReadLine());
                                    _building._floor[thatfloor - 1]._room[thatroom - 1]._sensor._movement[thatsensor - 1].Move();
                                }
                                else Console.Write("The building is free :)\n");
                                break;
                            }
                        case 4:
                            {
                                Console.Write("1. Replan room\n2. Delete room\n3. Add room\n");
                                int choice2 = Convert.ToInt32(Console.ReadLine());
                                switch (choice2)
                                {
                                    case 1:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                _building._floor[thatfloor - 1]._room[thatroom - 1] = null;
                                                Console.Write("Enter new data of room " + thatroom + "(volumePercent, countWindow, countDoor, length, width)\n");
                                                _building._floor[thatfloor - 1]._room[thatroom - 1] = new Room(_building._floor[thatfloor - 1].height, thatfloor, Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), thatroom);
                                                _building._floor[thatfloor - 1]._room[thatroom - 1].MakingDevices();
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatfloor, thatroom;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter room to delete ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                if (_building._floor[thatfloor - 1].countR != 1)
                                                {
                                                    _building._floor[thatfloor - 1].countR -= 1;
                                                }
                                                else
                                                {
                                                    Console.Write("Number of rooms in a floor cannot be 0\n");
                                                    break;
                                                }
                                                _building._floor[thatfloor - 1]._room = _building._floor[thatfloor - 1]._room - _building._floor[thatfloor - 1]._room[thatroom];
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatfloor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter data of new room (volumePercent, countWindow, countDoor, length, width)\n");
                                                _building._floor[thatfloor - 1].countR += 1;
                                                Room temp = new Room(_building._floor[thatfloor - 1].height, Building.CountF, Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), _building._floor[thatfloor - 1].countR + 1);
                                                temp.MakingDevices();
                                                _building._floor[thatfloor - 1]._room = _building._floor[thatfloor - 1]._room + temp;
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                break;
                            }
                        case 5:
                            {
                                _building.Inizialize();
                                break;
                            }
                        case 6:
                            {
                                Console.Write("\n1. Building\n2. Camera\n3. Device\n4. Floor\n5. Lamp\n6. Lighting\n7. Movement\n8. Room\n9. Sensor\n10. Temperature\n11. Valv\n");
                                int choice3 = Convert.ToInt32(Console.ReadLine());
                                switch (choice3)
                                {
                                    case 1:
                                        {
                                            Console.Write(_building.ToString());
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor, thatsensor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary camera ( " + _building._floor[thatfloor - 1]._room[thatroom - 1].CountCamera + " ): ");
                                                thatsensor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._device._camera[thatsensor].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._device.ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatfloor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 5:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor, thatsensor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary lamp ( " + _building._floor[thatfloor - 1]._room[thatroom - 1].CountCamera + " ): ");
                                                thatsensor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._device._lamp[thatsensor].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 6:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor, thatsensor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary lighting sensor( " + _building._floor[thatfloor - 1]._room[thatroom - 1].LightDevQuantity + " ): ");
                                                thatsensor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._sensor._lighting[thatsensor].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 7:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor, thatsensor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary movement sensor( " + _building._floor[thatfloor - 1]._room[thatroom - 1].MovDevQuantity + " ): ");
                                                thatsensor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._sensor._movement[thatsensor].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 8:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 9:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._sensor.ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 10:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor, thatsensor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary temperature sensor( " + _building._floor[thatfloor - 1]._room[thatroom - 1].MovDevQuantity + " ): ");
                                                thatsensor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._sensor._temperature[thatsensor].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    case 11:
                                        {
                                            if (Building.CountF != 0)
                                            {
                                                int thatroom, thatfloor, thatsensor;
                                                Console.Write("Enter necessary floor ( " + Building.CountF + " ): ");
                                                thatfloor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary room ( " + _building._floor[thatfloor - 1].countR + " ): ");
                                                thatroom = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("Enter necessary valv ( " + _building._floor[thatfloor - 1]._room[thatroom - 1].CountCamera + " ): ");
                                                thatsensor = Convert.ToInt32(Console.ReadLine());
                                                Console.Write(_building._floor[thatfloor - 1]._room[thatroom - 1]._device._valv[thatsensor].ToString());
                                            }
                                            else Console.Write("The building is free :)\n");
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Default case");
                                        break;
                                }
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("Good bye");
                                break;
                            }
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                }
            }
        }
    }
}

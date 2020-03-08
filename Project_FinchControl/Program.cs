using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Starter solution with the helper methods,
    //              opening and closing screens, and the menu
    // Application Type: Console
    // Author: Hosler, Robert
    // Dated Created: 1/22/2020
    // Last Modified: 2/23/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchRobot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchRobot);
                        break;

                    case "d":
                        DisplayLightAlarmMenuScreen(finchRobot);
                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void DisplayTalentShowMenuScreen(Finch myFinch)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Square Dance");
                Console.WriteLine("\tc) Mixing it Up");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(myFinch);
                        break;

                    case "b":
                        DisplayDance(myFinch);
                        break;

                    case "c":
                        DisplayMixingItUp(myFinch);
                        break;

                    case "d":

                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(0, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 10);
            }
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOn(0);
            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Display Dance                     *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDance(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("The Square");

            Console.WriteLine("\tThe Finch robot will now move in a square pattern!");
            Console.WriteLine("How many seconds would you like it to spend on each side?");
            int Duration = int.Parse(Console.ReadLine());
            DisplayContinuePrompt();
            for (int t = 1; t < 4; t++)
            { 
                finchRobot.setMotors(80, 100);
                System.Threading.Thread.Sleep(Duration*1000);
                finchRobot.setMotors(0, 100);
                System.Threading.Thread.Sleep(1500);            
                finchRobot.setMotors(0,0);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Mixing it Up                    *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayMixingItUp(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it up");

            Console.WriteLine("\tThe Finch robot will now move in a square pattern while flashing lights and making noise!");
            DisplayContinuePrompt();
 
            for (int t = 0; t < 4; t++)
            {           
                finchRobot.setMotors(80, 100);
                for (int lightSoundLevel = 0; lightSoundLevel < 100; lightSoundLevel++)
                {
                    finchRobot.setLED(0, lightSoundLevel, lightSoundLevel);
                    finchRobot.noteOn(lightSoundLevel * 50);
                }
                finchRobot.setMotors(0, 100);
                for (int lightSoundLevel = 100; lightSoundLevel > 0; lightSoundLevel--)
                {
                    finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                    finchRobot.noteOn(lightSoundLevel * 50);
                }
                finchRobot.setMotors(0, 0);
            }
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOn(0);

            DisplayMenuPrompt("Talent Show Menu");
        }
        #endregion

        #region DATA RECORDER

        static void DataRecorderDisplayMenuScreen(Finch finchRobot)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;

            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DataRecoderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayGetData(temperatures);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        /// <summary>
        /// Display Data
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayGetData(double[] temperatures)
        {
            DisplayScreenHeader("Dislay Data");

            //Display Table Header

            Console.WriteLine(
                "Recording".PadLeft(15) +
                "Temp".PadLeft(15)         
                );
            Console.WriteLine(
                "___________".PadLeft(15) +
                "____".PadLeft(15)
                );

            //Display table data
            for (int i = 0; i < temperatures.Length; i++)
            {
                Console.WriteLine(
                    (i+1).ToString().PadLeft(15) +
                    temperatures[i].ToString("n3").PadLeft(15)
                    );
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Obtain temperatures
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="finchRobot"></param>
        /// <returns>tempuratures</returns>
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] tempuratures = new double[numberOfDataPoints];
            
            DisplayScreenHeader("Get Data");

            Console.WriteLine($"The finch robot will collect {numberOfDataPoints} data points, with {dataPointFrequency} seconds between each one.");
            Console.WriteLine();
            Console.WriteLine("The finch robot is ready to record the tempurature");
            DisplayContinuePrompt();

            for (int i = 0; i < numberOfDataPoints; i++)
            {
                tempuratures[i] = finchRobot.getTemperature() *1.8 + 32;
                Console.WriteLine($"Reading {i+1}: {tempuratures[i].ToString("n3")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);
            }
            DisplayContinuePrompt();

            return tempuratures;
        }

        /// <summary>
        /// Get Data Point Frequency
        /// </summary>
        /// <returns>DataPointFrequency</returns>
        static double DataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            int c = 0;
            DisplayScreenHeader("Frequency of Data Points");

            Console.Write("Please enter how many seconds you would like between data point collections");
            double.TryParse(Console.ReadLine(), out dataPointFrequency);

            // Validate user input
            if (dataPointFrequency >= 0)
                c = 1;
            while (c != 1)
            {
                Console.WriteLine("Please enter a number above 0");
                double.TryParse(Console.ReadLine(), out dataPointFrequency);
                if (dataPointFrequency >= 0)
                    c = 1;
            }
            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// Get number of data points
        /// </summary>
        /// <returns>numberOfDataPoints</returns>
        static int DataRecoderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            int c = 0;
            DisplayScreenHeader("Number of Data Points");

            Console.Write("Please enter the number of data points you would like to have collected ");
            int.TryParse(Console.ReadLine(), out numberOfDataPoints);

            // Validate user input
            if (numberOfDataPoints >= 0)
                c = 1;
            while (c != 1)
            {
                Console.WriteLine("Please enter a valid integer");
                int.TryParse(Console.ReadLine(), out numberOfDataPoints);
                if (numberOfDataPoints >= 0)
                    c = 1;
            }
            DisplayContinuePrompt();

            return numberOfDataPoints;
        }


        #endregion

        #region ALARM SYSTEM

        static void DisplayLightAlarmMenuScreen(Finch finchRobot)
        {
            string sensorsToMonitor = "both";
            string rangeType = "minimum";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;
            
            Console.CursorVisible = true;

            bool quitMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Set Maximum/Minimum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor(finchRobot);
                        break;

                    case "b":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmDisplaySetMinMaxThresholdValue(rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmDisplaySetMaximumTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmDisplaySetAlarm(finchRobot, sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                        break;

                    case "q":
                        quitMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitMenu);
        }

        /// <summary>
        /// Set Alarm
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="timeToMonitor"></param>
        static void LightAlarmDisplaySetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor)
        {
            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"The finch robot will use {sensorsToMonitor} sensor(s) for up to {timeToMonitor} seconds unless the {rangeType} threshold of {minMaxThresholdValue} is passed.");
            Console.WriteLine();
            Console.WriteLine("The finch robot is ready to begin");
            DisplayContinuePrompt();

            for(int i = 0; i < timeToMonitor; i++)
            {
                if(sensorsToMonitor == "left")
                {
                    int left = finchRobot.getLeftLightSensor();
                    if (rangeType == "minimum" && left < minMaxThresholdValue)
                    {
                        Console.WriteLine("Current Light levels are beyond threshold set");
                        Console.WriteLine($"The finch is currently getting {left}");
                    }
                    else if (rangeType == "maximum" && left > minMaxThresholdValue)
                    {
                        Console.WriteLine("Current Light levels are beyond threshold set");
                        Console.WriteLine($"The finch is currently getting {left}");
                    }
                    else
                        Console.WriteLine($"The finch is currently getting {left}");
                }

                if (sensorsToMonitor == "right")
                {
                    int right = finchRobot.getRightLightSensor();
                    if (rangeType == "minimum" && right < minMaxThresholdValue)
                    {
                        Console.WriteLine("Current Light levels are beyond threshold set");
                        Console.WriteLine($"The finch is currently getting {right}");
                    }
                    else if (rangeType == "maximum" && right > minMaxThresholdValue)
                    {
                        Console.WriteLine("Current Light levels are beyond threshold set");
                        Console.WriteLine($"The finch is currently getting {right}");
                    }
                    else
                        Console.WriteLine($"The finch is currently getting {right}");
                }

                if (sensorsToMonitor == "both")
                {
                    int left = finchRobot.getLeftLightSensor();
                    int right = finchRobot.getRightLightSensor();
                    int both = (right + left) / 2;
                    if (rangeType == "minimum" && both < minMaxThresholdValue)
                    {
                        Console.WriteLine("Current Light levels are beyond threshold set");
                        Console.WriteLine($"The finch is currently getting {both}");
                    }
                    else if (rangeType == "maximum" && both > minMaxThresholdValue)
                    {
                        Console.WriteLine("Current Light levels are beyond threshold set");
                        Console.WriteLine($"The finch is currently getting {both}");
                    }
                    else
                        Console.WriteLine($"The finch is currently getting {both}");
                }
                finchRobot.wait(1000);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Set the threshold value
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchRobot"></param>
        /// <returns>minMaxThresholdValue</returns>
        static int LightAlarmDisplaySetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;
            int c = 0;

            DisplayScreenHeader("Min/Max Threshold");

            Console.WriteLine($"What would you like your {rangeType} threshold to be?");
            int.TryParse(Console.ReadLine(), out minMaxThresholdValue);

            // Validate user input
            if (minMaxThresholdValue >= 0)
                c = 1;
            while (c != 1)
            {
                Console.WriteLine("Please enter an integer above 0");
                int.TryParse(Console.ReadLine(), out minMaxThresholdValue);
                if (minMaxThresholdValue >= 0)
                    c = 1;
            }

            DisplayContinuePrompt();

            return minMaxThresholdValue;
        }

        /// <summary>
        /// Set Threshold type
        /// </summary>
        /// <returns>rangeType</returns>
        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType = "a";
            string menuChoice;

            DisplayScreenHeader("Set Range Type");
            
            Console.WriteLine("Would you like the Finch to alert you when it reaches a minimum threshold or maximum");
            Console.WriteLine();
            Console.WriteLine("\ta) Minimum");
            Console.WriteLine("\tb) Maximum");
            Console.Write("\t\tEnter Choice:");
            menuChoice = Console.ReadLine().ToLower();

            switch (menuChoice)
            {
                case "a":
                    Console.WriteLine("The alarm will go off when it reaches the minimum threshold");
                    rangeType = "minimum";
                    break;

                case "b":
                    Console.WriteLine("The alarm will go off if it reaches the maximum threshold");
                    rangeType = "maximum";
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a letter for the menu choice.");
                    DisplayContinuePrompt();
                    break;
            }
            DisplayContinuePrompt();

            return rangeType;
        }

        /// <summary>
        /// Set Sensors Used
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <returns>sensorsToMonitor</returns>
        static string LightAlarmDisplaySetSensorsToMonitor(Finch finchRobot)
        {
            string sensorsToMonitor = "both";
            string menuChoice;

            DisplayScreenHeader("Sensors to Monitor");

            int leftLight = finchRobot.getLeftLightSensor();
            int rightLight = finchRobot.getRightLightSensor();

            Console.WriteLine($"The left sensor is currently reading {leftLight}, and the right sensor is currently getting {rightLight}");
            Console.WriteLine("Which sensor would you like the system to gather data from");
            Console.WriteLine();
            Console.WriteLine("\ta) Left Sensor");
            Console.WriteLine("\tb) Right Sensor");
            Console.WriteLine("\tc) Both Sensors");
            Console.Write("\t\tEnter Choice:");
            menuChoice = Console.ReadLine().ToLower();

            switch (menuChoice)
            {
                case "a":
                    Console.WriteLine("The left sensor will be used for the alarm");
                    sensorsToMonitor = "left";
                    break;

                case "b":
                    Console.WriteLine("The right sensor will be used for the alarm");
                    sensorsToMonitor = "right";
                    break;

                case "c":
                    Console.WriteLine("Both sensors will be used for the alarm");
                    sensorsToMonitor = "both";
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a letter for the menu choice.");
                    DisplayContinuePrompt();
                    break;
            }
            DisplayContinuePrompt();

            return sensorsToMonitor;
        }

        /// <summary>
        /// Get Maximum Monitor Time
        /// </summary>
        /// <returns>timeToMonitor</returns>
        static int LightAlarmDisplaySetMaximumTimeToMonitor()
        {
            int timeToMonitor;
            int c = 0;
            DisplayScreenHeader("Maximum monitor time");

            Console.Write("Please enter the maximum number of seconds you would like the finch to monitor for.");
            int.TryParse(Console.ReadLine(), out timeToMonitor);

            // Validate user input
            if (timeToMonitor >= 0)
                c = 1;
            while (c != 1)
            {
                Console.WriteLine("Please enter an integer above 0");
                int.TryParse(Console.ReadLine(), out timeToMonitor);
                if (timeToMonitor >= 0)
                    c = 1;
            }
            DisplayContinuePrompt();

            return timeToMonitor;
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
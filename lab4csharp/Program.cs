using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using lab4csharp;

namespace lab4csharp
{
    internal class Program
    {
        public  class MyTime
    {
        private int hourTime;
        private int minuteTime;
        private int secondTime;

        public MyTime() {}
        public MyTime(int h, int m, int s) {

            this.hourTime = h;
            this.minuteTime = m;
            this.secondTime = s;
        }

        public int GetAllInSeconds(){
            return hourTime * 60 * 60 + minuteTime * 60 + secondTime;
        }
        public void Add5Seconds() {
            secondTime += 5;
            if (secondTime >= 60) {
                minuteTime += 1;
                secondTime -= 60;
                if (minuteTime >= 60) {
                    hourTime += 1;
                    minuteTime -= 60;
                    if (hourTime >=24)
                    {
                        hourTime = 0;

                    }
                }
            }
        }
        public void SetHours(int hours) {
            hourTime = hours;
        }
        public void SetMinutes(int minutes) {
            minuteTime = minutes;
        }
        public void SetSeconds(int Seconds) {
            secondTime = Seconds;
        }

        public int GetHours()  {
        return hourTime;
    }

        public int GetMinutes()  {
        return minuteTime;
    }

        public int GetSeconds()  {
        return secondTime;
    }
        public void PrintTime() {
            String h, m, s;
            if (hourTime < 10) {
                h = "0" + hourTime.ToString();
            }
            else {
                h = "" + hourTime.ToString();
            }
            if (minuteTime < 10) {
                m = "0" + minuteTime.ToString();
            }
            else {
                m = "" + minuteTime.ToString();
            }
            if (secondTime < 10) {
                s = "0" + secondTime.ToString();
            }
            else {
                s = "" + secondTime.ToString();
            }

            System.Console.WriteLine(h + ":" + m + ":" + s ) ;
        }
        public string ReturnFormattedTime() {
            string h, m, s, formattedTime;
            if (hourTime < 10) {
                h = "0" + hourTime.ToString();
            }
            else {
                h = "" + hourTime.ToString();
            }
            if (minuteTime < 10) {
                m = "0" + minuteTime.ToString();
            }
            else {
                m = "" + minuteTime.ToString();
            }
            if (secondTime < 10) {
                s = "0" + secondTime.ToString();
            }
            else {
                s = "" + secondTime.ToString();
            }
            formattedTime = h + " " + m + " " + s;
            return formattedTime;
        }

    };

        static List<MyTime> diskIn()
        {
            List<MyTime> arr = new List<MyTime>();
            int arrPos = 0;
            try
            {
                using (StreamReader fin = new StreamReader("input.txt"))
                {
                    string N;
                    List<string> check = new List<string>();
                    while ((N = fin.ReadLine()) != null)
                    {
                        check.Add(N);
                    }

                    for (int nline = 0; nline < check.Count; nline++)
                    {
                        String line = check[nline];
                        String hour = "";
                        String minute = "";
                        String second = "";
                        int spaceCounter = 0;
                        if (line != null && line[0] != null /*&& line.charAt(0) != NULL*/)
                        {
                            for (int i = 0; i < line.Length; i++)
                            {
                                if (line[i] == ' ') spaceCounter += 1;
                                if (spaceCounter == 0) hour += line[i];
                                if (spaceCounter == 1 && line[i] != ' ') minute += line[i];
                                if (spaceCounter >= 2)
                                {
                                    if (line[i] != ' ')
                                    {
                                        second += line[i];
                                    }

                                    if (i == line.Length)
                                    {
                                        second += line[i];
                                    }

                                    ;
                                }
                            }

                            MyTime T = new MyTime(int.Parse(hour), int.Parse(minute), int.Parse(second));
                            arr.Add(T);
                            arrPos += 1;
                        }
                    }
                    
                }
                
            }catch {
                Console.WriteLine("Файл не найден INPUT!");
            }
            return arr;
        }

        public static void diskOut(List<MyTime> array)
        {
            try
            {
                using (StreamWriter fout = new StreamWriter("output.txt"))
                {
                    for(int i = 0; i< array.Count; i++)
                    {
                        MyTime T = array[i];
                        fout.WriteLine(T.ReturnFormattedTime());
                    }
                }
            }catch {
                Console.WriteLine("Файл не найден! OUTPUT");
            }
        }


        public static void Main(string[] args)
        {
            /*Program.MyTime T = new Program.MyTime(23, 59, 50);

            T.PrintTime();
            T.Add5Seconds();
            T.PrintTime();
            T.Add5Seconds();
            T.PrintTime();
            T.Add5Seconds();
            T.PrintTime();
            System.Console.WriteLine(T.GetAllInSeconds() + " секунд");*/
            List<MyTime> a = diskIn();
            for (int i = 0; i < a.Count; i++)
            {
                MyTime T = a[i];
                T.PrintTime();
            }
            diskOut(a);
        }
    }
}


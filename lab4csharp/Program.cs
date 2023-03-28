﻿using System;

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

    };
        public static void Main(string[] args)
        {
            MyTime T = new MyTime(23, 59, 50);

            T.PrintTime();
            T.Add5Seconds();
            T.PrintTime();
            T.Add5Seconds();
            T.PrintTime();
            T.Add5Seconds();
            T.PrintTime();
            System.Console.WriteLine(T.GetAllInSeconds() + " секунд");
        }
    }
}
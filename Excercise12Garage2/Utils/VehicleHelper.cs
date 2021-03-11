﻿using System;
using System.Text;

namespace Excercise12Garage2.Utils
{
    public class VehicleHelper
    {
        /// <summary>
        /// Method create a text with information about how long ago dtParkedTime
        /// </summary>
        /// <param name="dtParkedTime">Date and time</param>
        /// <returns>String with text</returns>
        public static string CalculateParkedTime(DateTime dtParkedTime)
        {
            int iAddedtoStringBuilder = 0;
            StringBuilder strBuild = new StringBuilder();
            DateTime dtNow = DateTime.Now;

            TimeSpan dtResult = dtNow - dtParkedTime;

            double days = Math.Round(dtResult.TotalDays);
            double hours = Math.Round(dtResult.TotalHours);
            double min = Math.Round(dtResult.TotalMinutes);

            if (days > 0)
            {
                if(days > 1)
                    strBuild.Append((int)days + " days");
                else
                    strBuild.Append((int)days + " day");

                dtResult = dtResult.Subtract(new TimeSpan((int)days, 0, 0, 0));

                hours = Math.Round(dtResult.TotalHours);
                min = Math.Round(dtResult.TotalMinutes);
                iAddedtoStringBuilder++;
            }


            if (hours > 0)
            {
                if (iAddedtoStringBuilder > 0)
                    strBuild.Append(", ");

                if(hours > 1)
                    strBuild.Append((int)hours + " hours");
                else
                    strBuild.Append((int)hours + " hour");

                dtResult = dtResult.Subtract(new TimeSpan(0, (int)hours, 0, 0));

                min = Math.Round(dtResult.TotalMinutes);
                iAddedtoStringBuilder++;
            }


            if (min > 0)
            {
                if (iAddedtoStringBuilder > 0)
                    strBuild.Append(", ");

                if(min > 1)
                    strBuild.Append((int)min + " minutes");
                else
                    strBuild.Append((int)min + " minute");

                iAddedtoStringBuilder++;
            }


            if(iAddedtoStringBuilder == 0)
            {
                strBuild.Append("Recently parked");
            }

            return strBuild.ToString();
        }

        internal static string CalculatePrice(string parkedTime)
        {
            int pTime = Convert.ToInt32(parkedTime);
            int pricePerMinute = 3;
            var price = Convert.ToString(pTime * pricePerMinute);
            return price;
        }
    }
}

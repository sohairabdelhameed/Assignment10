using System;

namespace DurationProject
{
    class Duration
    {
        #region Properties
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        #endregion

        #region Constructor
        // Constructor with hours, minutes, and seconds
        public Duration(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
            NormalizeTime();
        }

        // Constructor with total seconds
        public Duration(int totalSeconds)
        {
            Hours = totalSeconds / 3600;
            Minutes = (totalSeconds % 3600) / 60;
            Seconds = totalSeconds % 60;
        }
        #endregion

        #region Method
        // Normalize the time to ensure minutes and seconds are within their normal range
        private void NormalizeTime()
        {
            Minutes += Seconds / 60;
            Seconds %= 60;
            Hours += Minutes / 60;
            Minutes %= 60;
        } 
        #endregion

        #region Override the Object.System Members
        // Override ToString method
        public override string ToString()
        {
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        }

        // Override Equals method
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Duration d = (Duration)obj;
            return (Hours == d.Hours) && (Minutes == d.Minutes) && (Seconds == d.Seconds);
        }

        // Override GetHashCode method
        public override int GetHashCode()
        {
            return Tuple.Create(Hours, Minutes, Seconds).GetHashCode();
        }
        #endregion

        #region Operators OverLoading
        // Implement operator overloading
        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(d1.Hours + d2.Hours, d1.Minutes + d2.Minutes, d1.Seconds + d2.Seconds);
        }

        public static Duration operator +(Duration d, int seconds)
        {
            return new Duration(d.Hours, d.Minutes, d.Seconds + seconds);
        }

        public static Duration operator +(int seconds, Duration d)
        {
            return d + seconds;
        }

        public static Duration operator ++(Duration d)
        {
            return new Duration(d.Hours, d.Minutes + 1, d.Seconds);
        }

        public static Duration operator --(Duration d)
        {
            return new Duration(d.Hours, d.Minutes - 1, d.Seconds);
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            int totalSeconds1 = d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds;
            int totalSeconds2 = d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds;
            return new Duration(totalSeconds1 - totalSeconds2);
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) > (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) < (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) >= (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return (d1.Hours * 3600 + d1.Minutes * 60 + d1.Seconds) <= (d2.Hours * 3600 + d2.Minutes * 60 + d2.Seconds);
        }

        public static explicit operator DateTime(Duration d)
        {
            return DateTime.Today.AddHours(d.Hours).AddMinutes(d.Minutes).AddSeconds(d.Seconds);
        } 
        #endregion


    }
}

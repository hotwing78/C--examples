using System;
using System.Collections.Generic;

namespace Hospital
{
    public class Patient
    {
        public int TimeToLive { get; private set; }
        public int TimeForProcedure { get; private set; }
        public int LastPossibleMoment { get; private set; }
        public int IntakeTime { get; set; } // time entering waiting room
        public int TimeEnteringER { get; set; } // time actually on er table

        public Patient(int ttl, int tableTime)
        {
            TimeToLive = ttl;
            TimeForProcedure = tableTime;
            LastPossibleMoment = -1;
            IntakeTime = -1;
        }

        public void setFinalOperationTime(int currentTime)
        {
            LastPossibleMoment = currentTime + TimeToLive;
        }
    }
}

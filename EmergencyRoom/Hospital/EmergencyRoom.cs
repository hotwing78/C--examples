using System;
using System.Collections.Generic;
using PriorityQueue;

namespace Hospital
{
    class Hospital
    {
        static public int CurrentTime { get; set; }
    }

    class ERTable
    {
        // estimated time of completion
        public int ETC { get; set; }
        public Patient Patient { get; private set; }

        public ERTable(Patient p)
        {
            Patient = p;
            ETC = p.TimeForProcedure + Hospital.CurrentTime;
        }
    }

    class TriageUnit
    {
        private readonly int seed = 23;
        private readonly Random rand;

        public TriageUnit()
        {
            rand = new Random(seed);
        }

        public List<Patient> getNewPatients()
        {
            List<Patient> newPatients = new List<Patient>();
            int numPatients = rand.Next(12);
            for (int i = 0; i < numPatients; i++)
            {
                // two hours max, average about 1 hour
                int expiryTime = rand.Next(100);
                expiryTime += 20; // At least 20 minutes to get to ER

                // up to 35 minutes on ER table
                int operationTime = rand.Next(20);
                operationTime += 5; // no less than 10.
                newPatients.Add(new Patient(expiryTime, operationTime));
            }
            return newPatients;
        }
    }

    class EmergencyRoom
    {
        public const int NUM_TABLES = 10;
        public const int numMinutes = 12*60; // one shift
        private TriageUnit triage = new TriageUnit();
        private IQueue<Patient> waitingQueue;
        // TODO:  You will need some ERTables, probably in some sort of data structure
        List<ERTable> ERtables = new List<ERTable>(NUM_TABLES);
        
        public void processPatients()
        {
            Hospital.CurrentTime = 0;
            bool usePriority = true;
            List<Patient> patientList;
            // TODO:  You'll need some counters and accumulators
            int expiry = 0;
            int totalPatients = 0;
            int patients_Seen = 0;
            int waitingPatients = 0;
            int totalWait = 0;
            int averageWait = 0;
            int averageERwait = 0;
            // this is for free
            if (usePriority)
                waitingQueue = new PriorityQueue<Patient>();
            else
                waitingQueue = new SimpleQueue<Patient>();

            while (Hospital.CurrentTime < numMinutes)
            {
               int i = 0;
             
                   while (i > ERtables.Count)
                   {
                       if (ERtables[i].ETC >= Hospital.CurrentTime)
                       {
                           ERtables.RemoveAt(i);

                       }
                       else
                       {
                           i++;
                       }

                   }
               
                patientList = triage.getNewPatients();

                foreach (Patient p in patientList)
                {
                    p.IntakeTime = Hospital.CurrentTime;
                    p.setFinalOperationTime(Hospital.CurrentTime);
                    waitingQueue.Add(p.LastPossibleMoment, p);
                    totalPatients++;
                }
              
                    while (waitingQueue.Count > 0 && ERtables.Count <= ERtables.Capacity)
                    {
                       
                            ERTable ER = new ERTable(waitingQueue.Remove());
                            totalWait +=  (Hospital.CurrentTime - ER.Patient.IntakeTime);
                            if (Hospital.CurrentTime <= ER.Patient.TimeToLive)
                            {
                                expiry++;
                            }
                            else
                            {
                                ER.Patient.TimeEnteringER = Hospital.CurrentTime;
                                patients_Seen++;
                                ERtables.Add(ER);
                               
                                averageERwait += ER.ETC;

                            }
                  
                    }
                
                  
                // TODO:  your code goes here
                    Hospital.CurrentTime += 10;
                    waitingPatients = waitingQueue.Count;
            }
            //waitingPatients = waitingQueue.Count;
            averageWait = totalWait / totalPatients;
            averageERwait = averageERwait / patients_Seen;
            Console.Write("Simulation run time: {0}\n", numMinutes);
            Console.Write("Total patients entering hospital: {0}\n", totalPatients);
            Console.Write("Patients served: {0}\n", patients_Seen);
            Console.Write("Patients that expired: {0}\n", expiry);
            Console.Write("Patients waiting at end of cycle: {0}\n", waitingPatients);
            Console.Write("Average wait time: {0}\n", averageWait);
            Console.Write("Average ER wait: {0}", averageERwait);
            // print time, total patients, max waiting, average waiting, expired patients
        }

        static void Main(string[] args)
        {

            EmergencyRoom er = new EmergencyRoom();
            er.processPatients();
            Console.ReadLine();
        }
    }
}

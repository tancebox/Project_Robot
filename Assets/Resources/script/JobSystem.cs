using UnityEngine;
using System.Collections;

public class JobSystem {

    private LobbyMgr m_LobbyMgr = null;

    

    private JobUnit[] JobObj = null;
    private JobUnit JobAngenieer = null;
    private JobUnit JobFire = null;

    //Singloton
    private static JobSystem _instance = null;
    public static JobSystem Instance
    {
        get
        {
            if (_instance == null)
                _instance = new JobSystem();
            return _instance;
        }
    }

    //建構式
    public JobSystem() {
    }

    

    public void init() {
        JobObj = new JobUnit[3];

        JobObj[0] = new JobUnit(0);
        JobObj[1] = new JobUnit(1);
        JobObj[2] = new JobUnit(2);
    }

    public string getJobName(int JobID)
    {
        string JobName = "";
        JobName = JobObj[JobID].GetJobUnitName();
        return JobName;
    }
    public int getJobLv(int JobID)
    {
        int JobLv = 0;
        JobLv = JobObj[JobID].GetJobUnitLv();
        return JobLv;
    }

}

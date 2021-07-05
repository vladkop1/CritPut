using System.Collections.Generic;
using System.Linq;

namespace CritPut
{
    class Critical
    {
        string readP;
        string saveP;
        public Critical(string readP, string saveP)
        { 
            this.readP = readP;
            this.saveP = saveP;
        }

        List<Activity> activities = new List<Activity>();
        List<Path> pathes = new List<Path>();
    
    int FSPosition()
    {
        foreach (Activity activity in activities)
            if (activities.Where(x => x.eventEnd == activity.eventStart).Count() == 0) return activity.eventStart;
        return -1;
    }

    int FEPosition()
    {
            foreach (Activity activity in activities)
                if (activities.Where(x => x.eventStart == activity.eventEnd).Count() == 0) return activity.eventEnd;
            return -1;
    }

    void CalculatePutei()
    {
        foreach (Activity activity in activities.Where(x => x.eventStart == FSPosition()))
        {
            pathes.Add(new Path { path = activity.eventStart + "-" + activity.eventEnd, lastTochk = activity.eventEnd, lenght = activity.time });
        }
        for (int i = 0; i < pathes.Count; i++)
        {
            foreach (Activity activity in activities.Where(x => x.eventStart == pathes[i].lastTochk))
            {
                pathes.Add(new Path { path = pathes[i].path + "--" + activity.eventEnd, lastTochk = activity.eventEnd, lenght = pathes[i].lenght + activity.time });
            }
        }
    }


    Path Fcritput()
    {
        int maxlen = 0;
            foreach (Path path in pathes.Where(x => x.lastTochk == FEPosition()))
            {
                if (path.lenght > maxlen) maxlen = path.lenght;
            }
            Path critput = pathes.Find(x => x.lenght == maxlen);
            return critput;
    }

        public void RaschetCritPut()
        {
            ReadSave.Read(readP, ref activities);
            CalculatePutei();
            var critP = Fcritput();
            ReadSave.Write(saveP, critP);
            pathes.Clear();
        }

    }
}

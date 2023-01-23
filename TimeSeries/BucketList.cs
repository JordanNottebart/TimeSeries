using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSeries
{
    public class BucketList
    {
        private List<Bucket> timeSeries = new List<Bucket>();        //Variabele
        public TitleBucket TitleBucket { get; set; }
        public BucketList()//Constructor
        {
        }
        //Property
        public List<Bucket> TimeSeries
        {
            get
            {
                return timeSeries;
            }
            set
            {
                timeSeries = value;
            }
        }
        //Indexer
        public Bucket this[int index]
        {
            get
            {
                return timeSeries[index];
            }
            set
            {
                timeSeries[index] = value;
            }
        }

        public void Add(Bucket bucket)//Method om bucket toe te voegen aan lijst
        {
            TimeSeries.Add(bucket);
        }
    }
}

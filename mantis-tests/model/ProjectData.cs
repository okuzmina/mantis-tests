using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class ProjectData
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public bool InheritGlobalCategories { get; set; }
        public bool StatusVisibility { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }

        public ProjectData(string name)
        {
            Name = name;
        }

        public ProjectData()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduHome.Models;
namespace EduHome.ViewModels
{
    public class BlogVM
    {
        public List<Blog> Blogs { get; set; }
        public List<Subscribe> Subscribes { get; set; }
        public List<Setting> Settings { get; set; }
    }
}

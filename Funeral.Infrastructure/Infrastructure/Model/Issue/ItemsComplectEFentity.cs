using Domain.Complect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Issue
{
    public class ItemsComplectEFentity
    {
        public int Id { get; set; }
        public List<ItemComplectEntity> Items { get; set; }
    }
}

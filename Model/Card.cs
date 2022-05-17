using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KeywordsTest.Model
{
    public class Card
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Position { get; set; }
        public int ProjectId { get; set; }
        public int ListId { get; set; }
        public DateTime Date { get; set; }
        public List<Department> Department { get; set; }
        public List<Team> Teams { get; set; }
        public Project Project { get; set; }
        public List List { get; set; }
    }
}

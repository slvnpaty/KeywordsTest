using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KeywordsTest.Dao;
using KeywordsTest.Model;

namespace KeywordsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        /// <summary>
        /// Returns a list of cards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Card>>> GetCard()
        {
            List<Card> Cards = new List<Card>();
            var data = _context.Card.ToListAsync();
            if (data.Result.Count > 0)
            {
                foreach (var card in data.Result)
                {
                    List<int> DepartamentId = _context.DepartamentByCard.Where(x => x.CardId.Equals(card.Id)).Select(x => x.DepartmentId).ToList();
                    List<int> TeamsId = _context.TeamByCard.Where(x => x.CardId.Equals(card.Id)).Select(x => x.TeamId).ToList();
                    card.List = _context.List.Where(x => x.Id.Equals(card.ListId)).FirstOrDefault();
                    card.Project = _context.Project.Where(x => x.Id.Equals(card.ProjectId)).FirstOrDefault();
                    card.Department = _context.Department.Where(x => DepartamentId.Contains(x.Id)).ToList();
                    card.Teams = _context.Teams.Where(x => TeamsId.Contains(x.Id)).ToList();
                    Cards.Add(card);
                }
            }

            return await Task.FromResult(Cards);
        }

        // GET: api/Cards/5
        /// <summary>
        /// Returns one card per identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            var card = await _context.Card.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            List<int> DepartamentId = _context.DepartamentByCard.Where(x => x.CardId.Equals(card.Id)).Select(x => x.DepartmentId).ToList();
            List<int> TeamsId = _context.TeamByCard.Where(x => x.CardId.Equals(card.Id)).Select(x => x.TeamId).ToList();
            card.List = _context.List.Where(x => x.Id.Equals(card.ListId)).FirstOrDefault();
            card.Project = _context.Project.Where(x => x.Id.Equals(card.ProjectId)).FirstOrDefault();
            card.Department = _context.Department.Where(x => DepartamentId.Contains(x.Id)).ToList();
            card.Teams = _context.Teams.Where(x => TeamsId.Contains(x.Id)).ToList();
            return card;
        }

        // PUT: api/Cards/5
        /// <summary>
        /// Change a card based on identifier
        /// </summary>
        /// <param name="id"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(int id, Card card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }
            _context.Entry(card).State = EntityState.Modified;

            if (DepartamentCardExists(id))
            {
                List<DepartamentByCard> departamentByCards = _context.DepartamentByCard.Where(x => x.CardId.Equals(id)).ToList();
                _context.DepartamentByCard.RemoveRange(departamentByCards);
            }
            if (TeamCardExists(id))
            {
                List<TeamByCard> teamByCards = _context.TeamByCard.Where(x => x.CardId.Equals(id)).ToList();
                _context.TeamByCard.RemoveRange(teamByCards);
            }

            try
            {
                List<int> departamentId = new List<int>();
                List<int> teamId = new List<int>();

               
                if (card.Department.Count > 0)
                    departamentId = card.Department.Select(X => X.Id).ToList();
                if (card.Teams.Count > 0)
                    teamId = card.Teams.Select(X => X.Id).ToList();

                card.Department = null;
                card.Teams = null;
                await _context.SaveChangesAsync();

                if (departamentId.Count > 0)
                    for (var i = 0; i < departamentId.Count; i++)
                        _context.DepartamentByCard.Add(new DepartamentByCard() { CardId = card.Id, DepartmentId = departamentId[i] });

                if (teamId.Count > 0)
                    for (var i = 0; i < teamId.Count; i++)
                        _context.TeamByCard.Add(new TeamByCard() { CardId = card.Id, TeamId = teamId[i] });

                await _context.SaveChangesAsync();

                card.Department = _context.Department.Where(x => departamentId.Contains(x.Id)).ToList();
                card.Teams = _context.Teams.Where(x => teamId.Contains(x.Id)).ToList();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cards
        /// <summary>
        /// Insert new Card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(Card card)
        {
            List<int> departamentId = new List<int>();
            List<int> teamId = new List<int>();
            card.Project = _context.Project.Where(x => x.Id.Equals(card.ProjectId)).FirstOrDefault();
            card.List = _context.List.Where(x => x.Id.Equals(card.ListId)).FirstOrDefault();
            if (card.Department.Count > 0)
                departamentId = card.Department.Select(X => X.Id).ToList();
            if (card.Teams.Count > 0)
                teamId = card.Teams.Select(X => X.Id).ToList();
            card.Department = null;
            card.Teams = null;
            _context.Card.Add(card);
            
            _context.SaveChanges();

            if (departamentId.Count > 0)
                for (var i = 0; i < departamentId.Count; i++)
                    _context.DepartamentByCard.Add(new DepartamentByCard() { CardId = card.Id, DepartmentId = departamentId[i] });

            if (teamId.Count > 0)
                for (var i = 0; i < teamId.Count; i++)
                    _context.TeamByCard.Add(new TeamByCard() { CardId = card.Id, TeamId = teamId[i] });
            
            await _context.SaveChangesAsync();

            card.Department = _context.Department.Where(x => departamentId.Contains(x.Id)).ToList();
            card.Teams = _context.Teams.Where(x => teamId.Contains(x.Id)).ToList();

           

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        // DELETE: api/Cards/5
        /// <summary>
        /// Delete a card by identifier
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(int id)
        {
            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            if (DepartamentCardExists(id))
            {
                List<DepartamentByCard> departamentByCard = _context.DepartamentByCard.Where(x => x.CardId.Equals(id)).ToList();
                _context.DepartamentByCard.RemoveRange(departamentByCard);
            }
            if (TeamCardExists(id))
            {
                List<TeamByCard> teamByCard = _context.TeamByCard.Where(x => x.CardId.Equals(id)).ToList();
                _context.TeamByCard.RemoveRange(teamByCard);
            }
            _context.Card.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }

        private bool DepartamentCardExists(int id)
        {
            return _context.DepartamentByCard.Any(e => e.CardId == id);
        }

        private bool TeamCardExists(int id)
        {
            return _context.TeamByCard.Any(e => e.CardId == id);
        }
    }
}

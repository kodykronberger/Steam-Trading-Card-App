using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderEntryEngine;

namespace OrderRepository
{
    /// <summary>
    /// The class which is used to represent the database repository.
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// The database order entry context.
        /// </summary>
        private OrderEntryContext repository = new OrderEntryContext();

        /// <summary>
        /// The event handler for when a card is added to the cards list.
        /// </summary>
        public event EventHandler<CardEventArgs> CardAdded;

        /// <summary>
        /// The event handler for when a game is added to the games list.
        /// </summary>
        public event EventHandler<GameEventArgs> GameAdded;

        /// <summary>
        /// The event handler for when a post is added to the inventories list.
        /// </summary>
        public event EventHandler<InventoryEventArgs> InventoryAdded;

        /// <summary>
        /// The event handler for when news is added to the news list.
        /// </summary>
        public event EventHandler<NewsEventArgs> NewsAdded;

        /// <summary>
        /// The event handler for when a post is added to the posts list.
        /// </summary>
        public event EventHandler<PostEventArgs> PostAdded;

        /// <summary>
        /// The event handler for when a post is added to the posts list.
        /// </summary>
        public event EventHandler<PostEventArgs> PostDeleted;

        /// <summary>
        /// The event handler for when a user is added to the users list.
        /// </summary>
        public event EventHandler<UserEventArgs> UserAdded;

        /// <summary>
        /// Adds a new card to the cards list.
        /// </summary>
        /// <param name="card">The card to be added.</param>
        public void AddCard(Card card)
        {
            // Prevents the same object from being added repeatedly.
            if (!this.ContainsCard(card))
            {
                this.repository.Cards.Add(card);

                if (this.CardAdded != null)
                {
                    this.CardAdded(this, new CardEventArgs(card));
                }
            }
        }

        /// <summary>
        /// Adds a new game to the games list.
        /// </summary>
        /// <param name="game">The game to be added.</param>
        public void AddGame(Game game)
        {
            // Prevents the same object from being added repeatedly.
            if (!this.ContainsGame(game))
            {
                this.repository.Games.Add(game);

                if (this.GameAdded != null)
                {
                    this.GameAdded(this, new GameEventArgs(game));
                }
            }
        }

        /// <summary>
        /// Adds a new inventory to the inventory list.
        /// </summary>
        /// <param name="inventory">The inventory to be added.</param>
        public void AddInventory(Inventory inventory)
        {
            // Prevents the same object from being added repeatedly.
            if (!this.ContainsInventory(inventory))
            {
                this.repository.Inventorys.Add(inventory);

                if (this.InventoryAdded != null)
                {
                    this.InventoryAdded(this, new InventoryEventArgs(inventory));
                }
            }
        }

        /// <summary>
        /// Adds a new news item to the news list.
        /// </summary>
        /// <param name="news">The news to be added.</param>
        public void AddNews(News news)
        {
            if (!this.ContainsNews(news))
            {
                this.repository.News.Add(news);

                if (this.NewsAdded != null)
                {
                    this.NewsAdded(this, new NewsEventArgs(news));
                }
            }
        }

        /// <summary>
        /// Adds a new post to the posts list.
        /// </summary>
        /// <param name="post">The post to be added.</param>
        public void AddPost(Post post)
        {
            // Prevents the same object from being added repeatedly.
            if (!this.ContainsPost(post))
            {
                this.repository.Posts.Add(post);

                if (this.PostAdded != null)
                {
                    this.PostAdded(this, new PostEventArgs(post));
                }
            }
        }

        /// <summary>
        /// Adds a new user to the users list.
        /// </summary>
        /// <param name="user">The card to be added.</param>
        public void AddUser(User user)
        {
            // Prevents the same object from being added repeatedly.
            if (!this.ContainsUser(user))
            {
                this.repository.Users.Add(user);

                if (this.UserAdded != null)
                {
                    this.UserAdded(this, new UserEventArgs(user));
                }
            }
        }

        /// <summary>
        /// Check for the existence of a card within the cards list.
        /// </summary>
        /// <param name="card">The card to search for.</param>
        /// <returns>A value indicating whether the card is in the list.</returns>
        public bool ContainsCard(Card card)
        {
            return this.GetCard(card.Id) != null;
        }

        /// <summary>
        /// Check for the existence of a game within the games list.
        /// </summary>
        /// <param name="game">The game to search for.</param>
        /// <returns>A value indicating whether the game is in the list.</returns>
        public bool ContainsGame(Game game)
        {
            return this.GetGame(game.Id) != null;
        }

        /// <summary>
        /// Check for the existence of a inventory within the inventories list.
        /// </summary>
        /// <param name="inventory">The inventory to search for.</param>
        /// <returns>A value indicating whether the inventory is in the list.</returns>
        public bool ContainsInventory(Inventory inventory)
        {
            return this.GetInventory(inventory.Id) != null;
        }

        /// <summary>
        /// Check for the existence of a news item within the news list.
        /// </summary>
        /// <param name="news">The news to search for.</param>
        /// <returns>A value indicating whether the news is in the list.</returns>
        public bool ContainsNews(News news)
        {
            return this.GetNews(news.Id) != null;
        }

        /// <summary>
        /// Check for the existence of a post within the posts list.
        /// </summary>
        /// <param name="post">The post to search for.</param>
        /// <returns>A value indicating whether the post is in the list.</returns>
        public bool ContainsPost(Post post)
        {
            return this.GetPost(post.Id) != null;
        }

        /// <summary>
        /// Check for the existence of a user within the users list.
        /// </summary>
        /// <param name="user">The user to search for.</param>
        /// <returns>A value indicating whether the card is in the list.</returns>
        public bool ContainsUser(User user)
        {
            return this.GetUser(user.Id) != null;
        }

        /// <summary>
        /// Search for a card within the cars list.
        /// </summary>
        /// <param name="id">The ID number of the card to search for.</param>
        /// <returns>The card that was found.</returns>
        public Card GetCard(int id)
        {
            return this.repository.Cards.Find(id);
        }

        /// <summary>
        /// Retrieves the repository's cards list.
        /// </summary>
        /// <returns>The list of cards.</returns>
        public List<Card> GetCards()
        {
            return new List<Card>(this.repository.Cards);
        }

        /// <summary>
        /// Search for a card within the cards list.
        /// </summary>
        /// <param name="name">The name of the card to search for.</param>
        /// <returns>The card that was found.</returns>
        public Card GetCardByName(string name)
        {
            var cards = new List<Card>(this.repository.Cards);
            Card foundCard = null;

            foreach (Card card in cards)
            {
                if (card.Name == name)
                {
                    foundCard = card;
                }
            }

            return foundCard;
        }

        /// <summary>
        /// Search for a game within the games list.
        /// </summary>
        /// <param name="id">The ID number of the game to search for.</param>
        /// <returns>The game that was found.</returns>
        public Game GetGame(int id)
        {
            return this.repository.Games.Find(id);
        }

        /// <summary>
        /// Retrieves the repository's game list.
        /// </summary>
        /// <returns>The list of game.</returns>
        public List<Game> GetGames()
        {
            return new List<Game>(this.repository.Games);
        }

        /// <summary>
        /// Search for a game within the games list.
        /// </summary>
        /// <param name="title">The title of the game to search for.</param>
        /// <returns>The game that was found.</returns>
        public Game GetGameByTitle(string title)
        {
            var games = new List<Game>(this.repository.Games);
            Game foundGame = null;

            foreach (Game game in games)
            {
                if (game.Title == title)
                {
                    foundGame = game;
                }
            }

            return foundGame;
        }

        /// <summary>
        /// Search for a post within the inventories list.
        /// </summary>
        /// <param name="id">The ID number of the inventory to search for.</param>
        /// <returns>The inventory that was found.</returns>
        public Inventory GetInventory(int id)
        {
            return this.repository.Inventorys.Find(id);
        }

        /// <summary>
        /// Retrieves the repository's inventory list.
        /// </summary>
        /// <returns>The list of inventory.</returns>
        public List<Inventory> GetInventorys()
        {
            return new List<Inventory>(this.repository.Inventorys);
        }

        /// <summary>
        /// Search for a news item within the news list.
        /// </summary>
        /// <param name="id">The ID number of the news to search for.</param>
        /// <returns>The news that was found.</returns>
        public News GetNews(int id)
        {
            return this.repository.News.Find(id);
        }

        /// <summary>
        /// Retrieves the repository's news list.
        /// </summary>
        /// <returns>The list of news.</returns>
        public List<News> GetNewsList()
        {
            return new List<News>(this.repository.News);
        }

        /// <summary>
        /// Search for a post within the posts list.
        /// </summary>
        /// <param name="id">The ID number of the post to search for.</param>
        /// <returns>The post that was found.</returns>
        public Post GetPost(int id)
        {
            return this.repository.Posts.Find(id);
        }

        /// <summary>
        /// Retrieves the repository's posts list.
        /// </summary>
        /// <returns>The list of posts.</returns>
        public List<Post> GetPosts()
        {
            return new List<Post>(this.repository.Posts);
        }

        /// <summary>
        /// Search for a user within the users list.
        /// </summary>
        /// <param name="id">The ID number of the user to search for.</param>
        /// <returns>The user that was found.</returns>
        public User GetUser(int id)
        {
            return this.repository.Users.Find(id);
        }

        /// <summary>
        /// Retrieves the repository's users list.
        /// </summary>
        /// <returns>The list of users.</returns>
        public List<User> GetUsers()
        {
            return new List<User>(this.repository.Users);
        }

        /// <summary>
        /// Search for a card within the cards list.
        /// </summary>
        /// <param name="name">The name of the user to search for.</param>
        /// <returns>The user that was found.</returns>
        public User GetUserByName(string name)
        {
            var users = new List<User>(this.repository.Users);
            User foundUser = null;

            foreach (User user in users)
            {
                if (user.Username == name)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        /// <summary>
        /// Search for a user within the users list.
        /// </summary>
        /// <param name="steamid">The steam id of the user to search for.</param>
        /// <returns>The user that was found.</returns>
        public User GetUserBySteamId(string steamid)
        {
            var users = new List<User>(this.repository.Users);

            User foundUser = null;

            foreach (User user in users)
            {
                if (user.SteamId == steamid)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        /// <summary>
        /// Removes a new post from the posts list.
        /// </summary>
        /// <param name="post">The post to be removed.</param>
        public void RemovePost(Post post)
        {
            // Prevents the same object from being deleted repeatedly.
            if (this.ContainsPost(post))
            {
                this.repository.Posts.Remove(post);

                if (this.PostDeleted != null)
                {
                    this.PostDeleted(this, new PostEventArgs(post));
                }
            }
        }

        /// <summary>
        /// Saves changes made to the database.
        /// </summary>
        public void SaveToDatabase()
        {
            this.repository.SaveChanges();
        }
    }
}
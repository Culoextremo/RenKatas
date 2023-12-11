using UnoRen;
using VistaLoquesea;

var player1 = new Player(new Card(Color.Yellow, 5), new Card(Color.Yellow, 3));
var player2 = new Player(new Card(Color.Yellow, 5));
var game = new Game(player1, player2, new DrawPile(new Card(Color.Yellow, 5)), new DiscardPile(new Card(Color.Yellow, 5)));

var doc = new ThrowCard(game);
var sut = new Gameplay(game, doc,  new FakeInput(0.5f, new Card(Color.Yellow, 5)), new ConsoleGameView());

await sut.Play();



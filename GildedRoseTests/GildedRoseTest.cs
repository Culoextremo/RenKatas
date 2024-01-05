using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void PassADay()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();

        sut.Items.Single().SellIn.Should().Be(9);
        sut.Items.Single().Quality.Should().Be(9);
    }
    
    [Test]
    public void QualityDecreasesDouble_AfterSellingDate()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 20 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(-1);
        sut.Items.Single().Quality.Should().Be(18);
    }
    
    [Test]
    public void QualityDecreasesNormaly_OnSellInDate()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 20 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(0);
        sut.Items.Single().Quality.Should().Be(19);
    }

    [Test]
    public void QualityIsNeverNegative()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 0 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(0);
        sut.Items.Single().Quality.Should().Be(0);
    }

    [Test]
    public void AgeCheese()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 7 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(4);
        sut.Items.Single().Quality.Should().Be(8);
    }
    
    [Test]
    public void AgeCheeseALot()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 7 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(-1);
        sut.Items.Single().Quality.Should().Be(9);
    }
    
    [Test]
    public void CapQuality()
    {
        var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().Quality.Should().Be(50);
    }

    [Test]
    public void Sulfuras()
    {
        var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(-1);
        sut.Items.Single().Quality.Should().Be(80);
    }
    
    [Test]
    public void Reventa()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 1 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(9);
        sut.Items.Single().Quality.Should().Be(3);
    }
    [Test]
    public void CasiReventa()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 1 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(10);
        sut.Items.Single().Quality.Should().Be(2);
    }
    
    [Test]
    public void ReventaQUEDAMUYPOCO()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 1 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(4);
        sut.Items.Single().Quality.Should().Be(4);
    }
    
    [Test]
    public void CasiReventaQUEDAMUYPOCO()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 1 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(5);
        sut.Items.Single().Quality.Should().Be(3);
    }
    [Test]
    public void VentaDeEntradas()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 20, Quality = 1 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(19);
        sut.Items.Single().Quality.Should().Be(2);
    }
    
    
    [Test]
    public void TePerdisteElConcierto()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(-1);
        sut.Items.Single().Quality.Should().Be(0);
    }
    
    [Test]
    public void sgdfhsdfgdsfgsdf()
    {
        var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 49 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(2);
        sut.Items.Single().Quality.Should().Be(50);
    }

    [Test]
    public void kjakdjaksjd()
    {
        var items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 } };
        var sut = new GildedRose(items);
        
        sut.EndDay();
        
        sut.Items.Single().SellIn.Should().Be(9);
        sut.Items.Single().Quality.Should().Be(8);
    }
}
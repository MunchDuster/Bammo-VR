using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
	public string name;
	public string symbol;

	public int protons;
	public int neutrons;
	public int group;
	public Element[] isotopes;
	
	public Element(int protons, int neutrons, string name, string symbol, int group)
	{
		this.name = name;
		this.symbol = symbol;
		this.protons = protons;
		this.neutrons = neutrons;
		this.group = group;
	}
	public Element(int protons, int neutrons, string name, string symbol)
	{
		this.name = name;
		this.symbol = symbol;
		this.protons = protons;
		this.neutrons = neutrons;
	}
	public Element(){}
}

public static class Chemistry
{
	private static Element[] elements = new Element[118]
	{
		new Element(1, 1, "Hydrogen","H"),
		new Element(2, 4, "Helium","He"),
		new Element(3, 6, "Lithium","Li"),
		new Element(4, 9, "Beryllium","Be"),
		new Element(5, 10, "Boron","B"),
		new Element(6, 12, "Carbon","C"),
		new Element(7, 14, "Nitrogen","N"),
		new Element(8, 15, "Oxygen","O"),
		new Element(9, 18, "Fluorine","F"),
		new Element(10, 20, "Neon","Ne"),
		new Element(11, 22, "Sodium","Na"),
		new Element(12, 24, "Magnesium","Mg"),
		new Element(13, 26, "Aluminium","Al"),
		new Element(14, 28, "Silicon","Si"),
		new Element(15, 30, "Phosphorus","P"),
		new Element(16, 32, "Sulfur","S"),
		new Element(17, 35, "Chlorine","Cl"),
		new Element(18, 39, "Argon","Ar"),
		new Element(19, 39, "Potassium","K"),
		new Element(20, 40, "Calcium","Ca"),
		new Element(21, 44, "Scandium","Sc"),
		new Element(22, 47, "Titanium","Ti"),
		new Element(23, 50, "Vanadium","V"),
		new Element(24, 51, "Chromium","Cr"),
		new Element(25, 54, "Manganese","Mn"),
		new Element(26, 55, "Iron","Fe"),
		new Element(27, 58, "Cobalt","Co"),
		new Element(28, 58, "Nickel","Ni"),
		new Element(29, 63, "Copper","Cu"),
		new Element(30, 65, "Zinc","Zn"),
		new Element(31, 69, "Gallium","Ga"),
		new Element(32, 72, "Germanium","Ge"),
		new Element(33, 74, "Arsenic","As"),
		new Element(34, 78, "Selenium","Se"),
		new Element(35, 79, "Bromine","Br"),
		new Element(36, 83, "Krypton","Kr"),
		new Element(37, 85, "Rubidium","Rb"),
		new Element(38, 87, "Strontium","Sr"),
		new Element(39, 88, "Yttrium","Y"),
		new Element(40, 91, "Zirconium","Zr"),
		new Element(41, 92, "Niobium","Nb"),
		new Element(42, 95, "Molybdenum","Mo"),
		new Element(43, 98, "Technetium","Tc"),
		new Element(44, 101, "Ruthenium","Ru"),
		new Element(45, 102, "Rhodium","Rh"),
		new Element(46, 106, "Palladium","Pd"),
		new Element(47, 107, "Silver","Ag"),
		new Element(48, 112, "Cadmium","Cd"),
		new Element(49, 114, "Indium","In"),
		new Element(50, 118, "Tin","Sn"),
		new Element(51, 121, "Antimony","Sb"),
		new Element(52, 127, "Tellurium","Te"),
		new Element(53, 126, "Iodine","I"),
		new Element(54, 131, "Xenon","Xe"),
		new Element(55, 132, "Caesium","Cs"),
		new Element(56, 137, "Barium","Ba"),
		new Element(57, 138, "Lanthanum","La"),
		new Element(58, 140, "Cerium","Ce"),
		new Element(59, 140, "Praseodymium","Pr"),
		new Element(60, 144, "Neodymium","Nd"),
		new Element(61, 144, "Promethium","Pm"),
		new Element(62, 150, "Samarium","Sm"),
		new Element(63, 151, "Europium","Eu"),
		new Element(64, 157, "Gadolinium","Gd"),
		new Element(65, 158, "Terbium","Tb"),
		new Element(66, 162, "Dysprosium","Dy"),
		new Element(67, 164, "Holmium","Ho"),
		new Element(68, 167, "Erbium","Er"),
		new Element(69, 168, "Thulium","Tm"),
		new Element(70, 173, "Ytterbium","Yb"),
		new Element(71, 174, "Lutetium","Lu"),
		new Element(72, 178, "Hafnium","Hf"),
		new Element(73, 180, "Tantalum","Ta"),
		new Element(74, 183, "Tungsten","W"),
		new Element(75, 186, "Rhenium","Re"),
		new Element(76, 190, "Osmium","Os"),
		new Element(77, 192, "Iridium","Ir"),
		new Element(78, 195, "Platinum","Pt"),
		new Element(79, 196, "Gold","Au"),
		new Element(80, 200, "Mercury","Hg"),
		new Element(81, 204, "Thallium","Tl"),
		new Element(82, 207, "Lead","Pb"),
		new Element(83, 208, "Bismuth","Bi"),
		new Element(84, 209, "Polonium","Po"),
		new Element(85, 210, "Astatine","At"),
		new Element(86, 222, "Radon","Rn"),
		new Element(87, 223, "Francium","Fr"),
		new Element(88, 226, "Radium","Ra"),
		new Element(89, 227, "Actinium","Ac"),
		new Element(90, 232, "Thorium","Th"),
		new Element(91, 231, "Protactinium","Pa"),
		new Element(92, 238, "Uranium","U"),
		new Element(93, 237, "Neptunium","Np"),
		new Element(94, 244, "Plutonium","Pu"),
		new Element(95, 243, "Americium","Am"),
		new Element(96, 247, "Curium","Cm"),
		new Element(97, 247, "Berkelium","Bk"),
		new Element(98, 251, "Californium","Cf"),
		new Element(99, 252, "Einsteinium","Es"),
		new Element(100, 257, "Fermium","Fm"),
		new Element(101, 258, "Mendelevium","Md"),
		new Element(102, 259, "Nobelium","No"),
		new Element(103, 266, "Lawrencium","Lr"),
		new Element(104, 267, "Rutherfordium","Rf"),
		new Element(105, 268, "Dubnium","Db"),
		new Element(106, 269, "Seaborgium","Sg"),
		new Element(107, 270, "Bohrium","Bh"),
		new Element(108, 277, "Hassium","Hs"),
		new Element(109, 278, "Meitnerium","Mt"),
		new Element(110, 281, "Darmstadtium","Ds"),
		new Element(111, 282, "Roentgenium","Rg"),
		new Element(112, 282, "Copernicium","Cn"),
		new Element(113, 286, "Nihonium","Nh"),
		new Element(114, 289, "Flerovium","Fl"),
		new Element(115, 290, "Moscovium","Mc"),
		new Element(116, 293, "Livermorium","Lv"),
		new Element(117, 294, "Tennessine","Ts"),
		new Element(118, 29, "Oganesson","O")

	};
	
	
	public static Element getElementFromNumber(int atomicNumber)
	{
		return elements[atomicNumber - 1];
	}
	public static Element getElementFromParticles(int protons, int neutrons)
	{
		foreach(Element element in elements)
		{
			if(element.protons == protons)
				if(element.neutrons == neutrons)
					return element;
				else
					foreach(Element isotope in element.isotopes)
					{
						if(element.neutrons == neutrons)
							return isotope;
					}
		}
		return new Element();
	}
}

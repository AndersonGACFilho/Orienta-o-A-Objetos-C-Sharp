﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Album
{
    public string Artista { get; set; }
    public string Name { get; set; }
    public List<Musica> Musicas { get;}

    private int DuracaoTotal = 0;

    public Album(List<Musica> musicas, string name)
    {
        Name = name;
        musicas.ForEach(musica =>
        {
            musica.setAlbum(Name);
            DuracaoTotal += musica.getDuracao();
        });
        Musicas = musicas;
    }

    public Album(string name)
    {
        Name = name;
        Musicas = new List<Musica>();
    }

    public void AdicionarMusica(Musica musica)
    {
        musica.setArtista(Artista);
        musica.setAlbum(Name);
        DuracaoTotal += musica.getDuracao();
        Musicas.Add(musica);
    }

    public void RemoverMusica(Musica musica)
    {
        DuracaoTotal -= musica.getDuracao();
        Musicas.Remove(musica);
    }

    public string getDuracaoTotal()
    {
        TimeSpan time = TimeSpan.FromSeconds(DuracaoTotal);
        string durationInMinutes = time.ToString(@"mm\:ss");
        return durationInMinutes;
    }

    public string DescricaoDetalhada()
    {
        int maxLength = Musicas.Max(musica => musica.ResumoMusica.Length);
        string pad = string.Empty.PadLeft(maxLength, '-');
        return $"\n{pad}\n\nAlbum: {Name}\nDuração Total: {getDuracaoTotal()}\n{AllMusicasToString()}\n{pad}\n";
    }

    private string AllMusicasToString()
    {
        string musicas = Musicas.Aggregate("", (current, musica) => current + $"{musica}\n");
        return musicas;
    }

    public override string ToString()
    {
        string returnedString = $"Album: {Name}\nDuração Total: {getDuracaoTotal()}\nNúmero de Musicas: {Musicas.Count}";
        string pad = string.Empty.PadLeft(returnedString.Length, '-');
        return $"{pad}\n{returnedString}\n{pad}\n";
    }
}

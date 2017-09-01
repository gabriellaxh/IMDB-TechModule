package imdb.entity;

import javax.persistence.*;

@Entity
@Table(name = "films")
public class Film {
    private int id;

    private String name;

    private String genre;

    private String director;

    private int year;

    public Film(String name, String genre, String director, int year) {
        this.id = id;
        this.name = name;
        this.genre = genre;
        this.director = director;
        this.year = year;
    }

    public Film() {

    }
@Id
@GeneratedValue(strategy = GenerationType.IDENTITY)
    public int getId() {
        return this.id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Column(nullable = false)
    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Column(nullable = false)
    public String getGenre() {
        return this.genre;
    }

    public void setGenre(String genre) {
        this.genre = genre;
    }

    @Column(nullable = false)
    public String getDirector() {
        return this.director;
    }

    public void setDirector(String director) {
        this.director = director;
    }

    @Column(nullable = false)
    public int getYear() {
        return this.year;
    }

    public void setYear(int year) {
        this.year = year;
    }
}
const Film = require('../models/Film');

module.exports = {
	index: (req, res) => {
        Film.find({}).then(films => {
        	res.render("film/index", {films: films});
		})
	},
	createGet: (req, res) => {
        res.render("film/create");
	},
	createPost: (req, res) => {
        let filmEntity = req.body;

        Film.create(filmEntity).then(film => {
        	res.redirect("/");
		})
	},
	editGet: (req, res) => {
        let filmId = req.params.id;

        Film.findById(filmId).then(film => {
        	res.render('film/edit', film);
		});
	},
	editPost: (req, res) => {
        let filmId = req.params.id;
		let filmEntity = req.body;

        Film.findByIdAndUpdate(filmId, filmEntity).then(film => {
            res.redirect('/');
        });
	},
	deleteGet: (req, res) => {
        let filmId = req.params.id;

        Film.findById(filmId).then(film => {
            res.render('film/delete', film);
        });
	},
	deletePost: (req, res) => {
        let filmId = req.params.id;

        Film.findByIdAndRemove(filmId).then(film => {
            res.redirect('/');
        });
	}
};
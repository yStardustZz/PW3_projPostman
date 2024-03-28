var FilmeModel = new function () {
    model = this;
    model.filmes = ko.observable();
    model.carregar = function () {
        $.ajax("http://localhost:54224/api/Filmes").done => model.filmes(data))
    }
}
ko.applyBindings(FilmeModel);
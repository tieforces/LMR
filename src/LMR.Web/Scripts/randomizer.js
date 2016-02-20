var hero = function (id, name, set, team) {
    self = this;
    self.id = ko.observable(id);
    self.name = ko.observable(name);
    self.set = ko.observable(set);
    self.team = ko.observable(team);
    self.optionName = ko.computed(function () {
        return self.name() + ' - ' + self.team().Value();
    });
};

function setupModel() {
    this.numberOfPlayers = ko.observable(0);
    this.heroes = ko.observableArray([]);
    this.villains = ko.observableArray([]);
    this.mastermind = ko.observable();
    this.scheme = ko.observable();
    this.henchmen = ko.observableArray([]);
};

var randomizerModel = function (data) {
    var self = this;
    ko.mapping.fromJS(data, {}, self);

    self.playerOptions = ko.observableArray([1, 2, 3, 4, 5]).extend({ required: true });
    self.henchmenOptions = ko.observableArray([]);
    self.heroOptions = ko.observableArray([]);
    self.mastermindOptions = ko.observableArray([]);
    self.schemeOptions = ko.observableArray([]);
    self.villainOptions = ko.observableArray([]);

    self.selectedPlayers = ko.observable();
    self.selectedMastermind = ko.observable();
    self.selectedScheme = ko.observable();
    self.selectedVillains = ko.observableArray([]);
    self.selectedHenchmen = ko.observableArray([]);
    self.selectedHeroes = ko.observableArray([]);

    for(var i = 0; i < self.Heroes().length;i++)
    {
        var teamId = self.Heroes()[i].Team();
        self.heroOptions.push(new hero(self.Heroes()[i].Id(), self.Heroes()[i].Name(), self.Heroes()[i].Set(), self.Teams()[teamId]));
    }

    self.displayBystanders = ko.computed(function () {
        try{
            return "Bystanders - " + self.selectedScheme().VillainDeck.Bystanders();
        }
        catch(e)
        {
            return null;
        }
    });

    self.displayTwists = ko.computed(function () {
        try{
            return "Scheme Twists - " + self.selectedScheme().VillainDeck.Twists();
        }
        catch(e)
        {
            return null;
        }
    });

    self.randomize = function () {
        if ($('#entryform').valid()) {

            // Mastermind
            if (self.selectedMastermind() == undefined) {
                var randomIndex = Math.floor(Math.random() * self.Masterminds().length);
                self.selectedMastermind(self.Masterminds()[randomIndex]);
            }

            // Scheme
            if (self.selectedScheme() == undefined) {
                var randomIndex = Math.floor(Math.random() * self.Schemes().length);
                self.selectedScheme(self.Schemes()[randomIndex]);
            }

            // Henchmen
            var userSelectedHenchmen = self.selectedHenchmen();
            self.selectedHenchmen([]);
            
            var requiredHenchmen = 1;

            if (self.selectedPlayers() >= 4)
            {
                requiredHenchmen++;
            }
            if (self.selectedScheme().VillainDeck.ExtraHenchmen() > 0)
            {
                requiredHenchmen += self.selectedScheme().VillainDeck.ExtraHenchmen();
            }

            if (self.selectedScheme().VillainDeck.Henchmen() != null) {
                var henchmenName = self.selectedScheme().VillainDeck.Henchmen();
                for (var i = 0; i < self.Henchmen().length; i++)
                {
                    if(henchmenName == self.Henchmen()[i].Name())
                    {
                        self.selectedHenchmen.push(self.Henchmen()[i]);
                    }
                }
            }
            if (requiredHenchmen != self.selectedHenchmen().length &&
                self.selectedMastermind().VillainDeck.Henchmen() != null) {
                var henchmenName = self.selectedMastermind().VillainDeck.Henchmen();
                for (var i = 0; i < self.Henchmen().length; i++)
                {
                    if(henchmenName == self.Henchmen()[i].Name())
                    {
                        self.selectedHenchmen.push(self.Henchmen()[i]);
                    }
                }
            }

            while (requiredHenchmen != self.selectedHenchmen().length) {
                if (userSelectedHenchmen.length > 0) {
                    self.selectedHenchmen.push(userSelectedHenchmen.shift());
                }
                else {
                    var randomIndex = Math.floor(Math.random() * self.Henchmen().length);
                    self.selectedHenchmen.push(self.Henchmen()[randomIndex]);
                }
            }

            // Villain
            var userSelectedVillains = self.selectedVillains();
            self.selectedVillains([]);

            var requiredVillains = 1;

            switch(self.selectedPlayers())
            {
                case 2:
                    requiredVillains++;
                    break;
                case 3:
                case 4:
                    requiredVillains += 2;
                    break;
                case 5:
                    requiredVillains += 3;
            }

            if (self.selectedScheme().VillainDeck.ExtraVillains() > 0)
            {
                requiredVillains += self.selectedScheme().VillainDeck.ExtraVillains();
            }

            if (self.selectedMastermind().VillainDeck.ExtraVillains() > 0)
            {
                requiredVillains += self.selectedMastermind().VillainDeck.ExtraVillains();
            }

            if (self.selectedScheme().VillainDeck.Villain() != null)
            {
                for (var i = 0; i < self.Villains().length; i++)
                {
                    if(self.selectedScheme().VillainDeck.Villain() == self.Villains()[i].Name())
                    {

                        self.selectedVillains.push(self.Villains()[i]);
                    }
                }
            }

            if (self.selectedMastermind().VillainDeck.Villain() != null &&
                self.selectedVillains().length != requiredVillains)
            {
                for(var i = 0; i < self.Villains().length; i++)
                {
                    if(self.selectedMastermind().VillainDeck.Villain() == self.Villains()[i].Name())
                    {
                        self.selectedVillains.push(self.Villains()[i]);
                    }
                }
            }

            while (requiredVillains != self.selectedVillains().length) {
                if (userSelectedVillains.length > 0) {
                    self.selectedVillains.push(userSelectedVillains.shift());
                }
                else {
                    var randomIndex = Math.floor(Math.random() * self.Villains().length);
                    self.selectedVillains.push(self.Villains()[randomIndex]);
                }
            }

            // Hero
            var userSelectedHeroes = self.selectedHeroes();
            self.selectedHeroes([]);

            var requiredHeroes = 3;
            if (self.selectedPlayers() > 1 && self.selectedPlayers() < 5)
            {
                requiredHeroes = 5;
            }
            else if (self.selectedPlayers() == 5)
            {
                requiredHeroes = 6;
            }

            try{
                if (self.selectedScheme().HeroDeck() != undefined)
                {
                    if (self.selectedScheme().HeroDeck.Heroes() > 0) {
                        requiredHeroes = self.selectedScheme().HeroDeck.Heroes();
                    }
                }
            }
            catch(e)
            {

            }
            while (requiredHeroes != self.selectedHeroes().length) {
                if (userSelectedHeroes.length > 0) {
                    for (var i = 0; i < self.Heroes().length; i++) {
                        if (self.Heroes()[i].Id() == userSelectedHeroes[0].id()) {
                            self.selectedHeroes.push(self.Heroes()[i]);
                            userSelectedHeroes.shift();
                            alert('added');
                            break;
                        }
                    }
                }
                else {
                    var randomIndex = Math.floor(Math.random() * self.Heroes().length);
                    var found = false;
                    for (var i = 0; i < self.selectedHeroes().length; i++) {
                        if (self.Heroes()[randomIndex].Id() == self.selectedHeroes()[i].Id()) {
                            found = true;
                            break;
                        }
                    }

                    if (!found) {
                        self.selectedHeroes.push(self.Heroes()[randomIndex]);
                    }
                }
            }

            $('#results').show();
            $('#results2').show();
        }
    };

    self.reset = function () {
        $('#results').hide();
        $('#results2').hide();

        self.selectedHenchmen([]);
        self.selectedHeroes([]);
        self.selectedMastermind('');
        self.selectedPlayers(0);
        self.selectedScheme('');
        self.selectedVillains([]);
    };

    self.save = function () {
        self.NewGame.Henchmen = self.selectedHenchmen();
        self.NewGame.Heroes = self.selectedHeroes();
        self.NewGame.Mastermind = self.selectedMastermind();
        self.NewGame.NumberOfPlayers = self.selectedPlayers();
        self.NewGame.Scheme = self.selectedScheme();
        self.NewGame.Villains = self.selectedVillains();

        var data = ko.toJSON(self.NewGame);

        $.ajax({
            type: "POST",
            url: "Home/Save",
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (result) {
                // todo - go to games page
            }
        });
    };
};
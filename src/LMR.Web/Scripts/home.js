function villainDeckModel(additionalInfo, bystanders, henchmen, twists, villain) {
    this.additionalInfo = ko.observable(additionalInfo);
    this.bystanders = ko.observable(bystanders);
    this.henchmen = ko.observable(henchmen);
    this.twists = ko.observable(twists);
    this.villain = ko.observable(villain);
    this.selectedVillains = ko.observableArray([]);
    this.selectedHenchmen = ko.observableArray([]);

    this.addVillain = ko.computed({
        read: function(){
            return "test";
        },
        write: function (value) {
            var found = false;
            for (var i = 0; i < this.selectedVillains().length; i++) {
                if (this.selectedVillains()[i].Name == value.Name) {
                    found = true;
                }
            }
            if (!found) {
                this.selectedVillains().push(value);
            }
        },
        owner: this
    });
    this.addHenchmen = ko.computed({
        read: function(){
            return "test";
        },
        write: function (value) {
            var found = false;
            for (var i = 0; i < this.selectedHenchmen().length; i++) {
                if (this.selectedHenchmen()[i].Name == value.Name) {
                    found = true;
                }
            }
            if (!found) {
                this.selectedHenchmen().push(value);
            }
        },
        owner: this
    });
};
function villainDeckRequirementsModel(additionalInfo, bystanders, henchmen, selectedHenchmen, selectedVillain, twists, villain) {
    this.additionalInfo = ko.observable(additionalInfo);
    this.bystanders = ko.observable(bystanders);
    this.henchmen = ko.observable(henchmen);
    this.selectedHenchmen = ko.observable(selectedHenchmen);
    this.selectedVillain = ko.observable(selectedVillain);
    this.twists = ko.observable(twists);
    this.villain = ko.observable(villain);
};
function heroDeckModel(additionalInfo, bystanders, hero) {
    this.additionalInfo = ko.observable(additionalInfo);
    this.bystanders = ko.observable(bystanders);
    this.hero = ko.observable(hero);
    this.selectedHeroes = ko.observableArray([]);

    this.addHero = ko.computed({
        read: function(){
            return "test";
        },
        write: function (value) {
            var found = false;
            for (var i = 0; i < this.selectedHeroes().length; i++) {
                if (this.selectedHeroes()[i].Name == value.Name) {
                    found = true;
                }
            }
            if (!found) {
                this.selectedHeroes().push(value);
            }
        },
        owner: this
    });
}
function heroDeckRequirementsModel(additionalInfo, bystanders, hero) {
    this.additionalInfo = ko.observable();
    this.bystanders = ko.observable();
    this.hero = ko.observable();
};
function mastermindModel(additionalInfo, expansion, masterStrike, name, villainDeck) {
    this.name = ko.observable(name);
    this.expansion = ko.observable(expansion);
    this.additionalInfo = ko.observable(additionalInfo);
    this.villainDeckRequirements = ko.observable(new villainDeckRequirementsModel(villainDeck.AdditionalInfo, '', '', villainDeck.SelectedHenchmen, villainDeck.SelectedVillain, '', ''));
    this.masterStrike = ko.observable(masterStrike);
};
function schemeModel(evilWins, expansion, name, specialRules, twist, villainDeck) {
    this.name = ko.observable(name);
    this.expansion = ko.observable(expansion);
    this.evilWins = ko.observable(evilWins);
    this.specialRules = ko.observable(specialRules);
    this.twist = ko.observable(twist);
    this.villainDeckRequirements = ko.observable(new villainDeckRequirementsModel(villainDeck.AdditionalInfo, villainDeck.Bystanders, villainDeck.Henchmen, villainDeck.SelectedHenchmen, villainDeck.SelectedVillain, villainDeck.Twists, villainDeck.Villain));
    this.heroDeckRequirements = ko.observable(new heroDeckRequirementsModel('', '', ''));

    this.manageHeroDeckRequirements = ko.computed({
        read: function () {
            return "test";
        },
        write: function (heroDeck) {
            if (heroDeck != null) {
                this.heroDeckRequirements(new heroDeckRequirementsModel(heroDeck.AdditionalInfo, heroDeck.Bystanders, heroDeck.Hero))
            }
        },
        owner: this
    });
};
function setupModel() {
    this.numberOfPlayers = ko.observable(0);
    this.numberOfVillains = ko.observable(0);
    this.numberOfHeroes = ko.observable(0);
    this.numberOfBystanders = ko.observable(0);
    this.villainDeck = ko.observable(new villainDeckModel('', '', '', '', ''));
    this.heroDeck = ko.observable(new heroDeckModel('', '', ''));
    this.mastermind = ko.observable(new mastermindModel('', '', '', '', ''));
    this.scheme = ko.observable(new schemeModel('', '', '', '', '', ''));
    this.isHenchmenMet = ko.observable(false);
    this.isVillainMet = ko.observable(false);
    this.isHeroMet = ko.observable(false);
    this.setNumberOfHenchmen = ko.computed({
        read: function () {
            if(this.villainDeck().selectedHenchmen().length < this.villainDeck().henchmen())
            {
                return false;
            }
            else {
                return true;
            }
        },
        write: function (players) {
            this.villainDeck().henchmen(getBaseNumberOfHenchmen(players));
            if(this.mastermind().villainDeckRequirements().henchmen() != '')
            {
                this.villainDeck().henchmen(parseInt(this.villainDeck().henchmen()) + parseInt(this.mastermind().villainDeckRequirements().henchmen()));
            }
            if(this.scheme().villainDeckRequirements().henchmen() != '')
            {
                this.villainDeck().henchmen(parseInt(this.villainDeck().henchmen()) + parseInt(this.scheme().villainDeckRequirements().henchmen()));
            }
        },
        owner: this
    });
    this.setNumberOfVillains = ko.computed({
        read: function () {
            if (this.villainDeck().selectedVillains().length < this.villainDeck().villain()) {
                return false;
            }
            else {
                return true;
            }
        },
        write: function (players) {
            this.villainDeck().villain(getBaseNumberOfVillains(players));
            if (this.mastermind().villainDeckRequirements().villain() != '') {
                this.villainDeck().villain(parseInt(this.villainDeck().villain()) + parseInt(this.mastermind().villainDeckRequirements().villain()));
            }
            if (this.scheme().villainDeckRequirements().villain() != '') {
                this.villainDeck().villain(parseInt(this.villainDeck().villain()) + parseInt(this.scheme().villainDeckRequirements().villain()));
            }
        },
        owner: this
    });
    this.setNumberOfHeroes = ko.computed({
        read: function () {
            if (this.heroDeck().selectedHeroes().length < this.heroDeck().hero()) {
                return false;
            }
            else {
                return true;
            }
        },
        write: function (players) {
            this.heroDeck().hero(getBaseNumberOfHeroes(players));
            //if (this.mastermind().heroDeckRequirements().hero() != '') {
            //    this.heroDeck().hero(parseInt(this.heroDeck().hero()) + parseInt(this.mastermind().heroDeckRequirements().hero()));
            //}
            if (this.scheme().heroDeckRequirements().hero() != undefined && this.scheme().heroDeckRequirements().hero() != '') {
                if (this.scheme().heroDeckRequirements().hero() == '6') {
                    this.heroDeck().hero(6);
                }
                else {
                    this.heroDeck().hero(parseInt(this.heroDeck().hero()) + parseInt(this.scheme().heroDeckRequirements().hero()));
                }
            }
        },
        owner: this
    });

    this.getRequiredHenchmenFromMastermind = ko.computed({
        read: function () {
            if (this.mastermind().villainDeckRequirements().selectedHenchmen() != '') {
                return this.mastermind().villainDeckRequirements().selectedHenchmen();
            }
            else {
                return undefined;
            }
        },
        owner: this
    });
    this.getRequiredHenchmenFromScheme = ko.computed({
        read: function () {
            if (this.scheme().villainDeckRequirements().selectedHenchmen() != '') {
                return this.scheme().villainDeckRequirements().selectedHenchmen();
            }
            else {
                return undefined;
            }
        },
        owner: this
    });
    this.getRequiredVillainFromMastermind = ko.computed({
        read: function () {
            if (this.mastermind().villainDeckRequirements().selectedVillain() != '') {
                return this.mastermind().villainDeckRequirements().selectedVillain();
            }
            else {
                return undefined;
            }
        },
        owner: this
    });
    this.getRequiredVillainFromScheme = ko.computed({
        read: function () {
            if (this.scheme().villainDeckRequirements().selectedVillain() != '') {
                return this.scheme().villainDeckRequirements().selectedVillain();
            }
            else {
                return undefined;
            }
        },
        owner: this
    });
    this.addVillain = ko.computed({
        read: function(){
            return "test";
        },
        write: function (value) {
            this.villainDeck().addVillain(value);
            if (this.villainDeck().selectedVillains().length < this.villainDeck().villain()) {
                this.isVillainMet(false);
            }
            else {
                this.isVillainMet(true);
            }
        },
        owner: this
    });
    this.addHenchmen = ko.computed({
        read: function(){
            return "test";
        },
        write: function (value) {
            this.villainDeck().addHenchmen(value);
            if (this.villainDeck().selectedHenchmen().length < this.villainDeck().henchmen()) {
                this.isHenchmenMet(false);
            }
            else {
                this.isHenchmenMet(true);
            }
        },
        owner:this
    });
    this.addHero = ko.computed({
        read: function () {
            return "test";
        },
        write: function (value) {
            this.heroDeck().addHero(value);
            if (this.heroDeck().selectedHeroes().length < this.heroDeck().hero()) {
                this.isHeroMet(false);
            }
            else {
                this.isHeroMet(true);
            }
        },
        owner: this
    });
};
function getBaseNumberOfHenchmen(players) {
    switch (players) {
        case 1:
        case 2:
        case 3:
            return 1;
        case 4:
        case 5:
            return 2;
    }
};
function getBaseNumberOfVillains(players) {
    switch (players) {
        case 1:
            return 1;
        case 2:
            return 2;
        case 3:
        case 4:
            return 3;
        case 5:
            return 4;
    }
};
function getBaseNumberOfBystanders(players) {
    switch (players) {
        case 1:
            return 1;
        case 2:
            return 2;
        case 3:
        case 4:
            return 8;
        case 5:
            return 12;
    }
};
function getBaseNumberOfHeroes(players) {
    switch (players) {
        case 1:
            return 3;
        case 2:
        case 3:
        case 4:
            return 5;
        case 5:
            return 6;
    }
};
function displayResults(scheme, mastermind, villainDeck, heroDeck) {
    $('#results').show();
    $('#results2').show();

    // Scheme
    var schemeResult = "<h4>" + scheme.name() + "</h4>";
    if (scheme.expansion() != undefined)
    {
        schemeResult += "<label>Expansion:&nbsp;</label>" + scheme.expansion() + "<br/>";
    }
    schemeResult += "<label>Twist:&nbsp;</label>" + scheme.twist() + "<br/><label>Evil Wins:&nbsp;</label>" + scheme.evilWins();
    if (scheme.specialRules() != undefined)
    {
        schemeResult += "<br/><label>Special Rules:&nbsp;</label>" + scheme.specialRules();
    }
    $('#scheme').html(schemeResult);

    // Mastermind
    var mastermindResult = "<h4>" + mastermind.name() + "</h4>";
    if(mastermind.expansion() != undefined)
    {
        mastermindResult += "<label>Expansion:&nbsp;</label>" + mastermind.expansion() + "<br/>";
    }
    
    mastermindResult += "<label>Masterstrike:&nbsp;</label>" + mastermind.masterStrike() + "<br/>";
    
    if(mastermind.additionalInfo() != null)
    {
        mastermindResult += "<label>Additional Info:&nbsp;</label>" + mastermind.additionalInfo() + "<br/>";
    }
    $('#mastermind').html(mastermindResult);

    // Villain Deck
    var villainDeckResult = "<label>Villains: </label><p><ul>";
    for(var i = 0; i < villainDeck.selectedVillains().length; i++)
    {
        villainDeckResult += "<li>" + villainDeck.selectedVillains()[i].Name + "</li>";
    }
    villainDeckResult += "</ul><br/><label>Henchmen:&nbsp;</label><ul>";
    for (var i = 0; i < villainDeck.selectedHenchmen().length; i++)
    {
        villainDeckResult += "<li>" + villainDeck.selectedHenchmen()[i].Name + "</li>";
    }
    villainDeckResult += "</ul><br/><label>Number of Bystanders:&nbsp;</label>" + villainDeck.bystanders();

    $('#villainDeck').html(villainDeckResult);

    // Hero Deck
    var heroDeckResult = "<label>Heroes: </label><p><ul>";
    for (var i = 0; i < heroDeck.selectedHeroes().length; i++) {
        heroDeckResult += "<li>" + heroDeck.selectedHeroes()[i].Name + "</li>";
    }
    heroDeckResult += "</ul>";
    if (heroDeck.additionalInfo() != '')
    {
        heroDeckResult += "<label>Additional Info:&nbsp;</label>" + heroDeck.additionalInfo() + "<br/>";
    }
    if (heroDeck.bystanders.length > 0)
    {
        heroDeckResult += "<br/><label>Number of Bystanders:&nbsp;</label>" + heroDeck.bystanders();
    }
    $('#heroDeck').html(heroDeckResult);
};
﻿SELECT nom, prenom , solde, compte.id  from bank_client as client inner join  bank_compte as compte on compte.idClient = client.id where client.telephone = 02;
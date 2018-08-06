CREATE TABLE VacationSuggestion (
	id int,
	DestinationName varchar(70),
	Attractions varchar(150),
	BestTimeToGo varchar(30),
)

SELECT * FROM VacationSuggestion

INSERT INTO VacationSuggestions(id, DestinationName, Attractions, BestTimeToGo) VALUES (1, 'Reno', 'Tahoe', 'Summer');

SELECT * FROM VacationSuggestion
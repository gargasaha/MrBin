create table State(
    StateId varchar(2) primary key,
    StateName varchar(100)
);

create table Dist(
    DistId varchar(3) primary key,
    DistName varchar(100),
    Stateid varchar(2) 
);

alter table Dist add FOREIGN KEY (StateId) REFERENCES State(StateId);
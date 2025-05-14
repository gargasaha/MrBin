

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

-- may12
create table ZipCode(
    ZCode varchar(6) primary key,
    DistId varchar(5) not null
)
alter table ZipCode add foreign key(DistId) REFERENCES Dist(DistId)


create table Usr(
    UserId varchar(13) PRIMARY KEY,
    UserName varchar(100) not null,
    UserZipCode varchar(6) not null,
    UserProfileImage varbinary(max) not null,
    UserPassword binary(64) not null
)
alter table Usr add FOREIGN KEY (UserZipCode) REFERENCES ZipCode(ZCode) ON DELETE CASCADE;
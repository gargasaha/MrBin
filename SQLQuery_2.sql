

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
    ZCode varchar(6) not null,
    DistId varchar(5) not null,
    AreaName varchar(100)
)
alter table ZipCode add foreign key(DistId) REFERENCES Dist(DistId)

INSERT INTO ZipCode VALUES
('732101', 'D-179', 'English Bazar'),
('732128', 'D-179', 'Old Malda'),
('732201', 'D-179', 'Kaliachak'),
('732123', 'D-179', 'Chanchal'),
('732125', 'D-179', 'Harishchandrapur'),
('732202', 'D-179', 'Manikchak'),
('732124', 'D-179', 'Gajol'),
('732147', 'D-179', 'Bamangola'),
('732210', 'D-179', 'Baishnabnagar'),
('732103', 'D-179', 'Rajbati Ramnagar'),
('732207', 'D-179', 'Mothabari'),
('732139', 'D-179', 'Samsi'),
('732211', 'D-179', 'Milki'),
('732138', 'D-179', 'Pakuahat'),
('732216', 'D-179', 'Mahadipur'),
('732142', 'D-179', 'Mangalbari'),
('732212', 'D-179', 'Jadupur'),
('732204', 'D-179', 'Paranpur'),
('732213', 'D-179', 'Pukhuria'),
('732215', 'D-179', 'Pubarun'),
('732141', 'D-179', 'Narayanpur'),
('732208', 'D-179', 'Niamatpur'),
('732140', 'D-179', 'Bhatolchandipur'),
('732126', 'D-179', 'Naikanda'),
('732123', 'D-179', 'Ismailpur'),
('732125', 'D-179', 'Malior'),
('732101', 'D-179', 'Netaji Subhas Road'),
('732128', 'D-179', 'Balia Nawabganj'),
('732123', 'D-179', 'Jagannathpur'),
('732124', 'D-179', 'Katna'),
('732123', 'D-179', 'Mallikpara'),
('732124', 'D-179', 'Hatimari'),
('732124', 'D-179', 'Katikandar'),
('732124', 'D-179', 'Shivajinagar'),
('732124', 'D-179', 'Mayna');






create table Usr(
    UserId varchar(13) PRIMARY KEY,
    UserName varchar(100) not null,
    UserZipCode varchar(6) not null,
    UserProfileImage varbinary(max) not null,
    UserPassword binary(64) not null
)
alter table Usr add FOREIGN KEY (UserZipCode) REFERENCES ZipCode(ZCode) ON DELETE CASCADE;
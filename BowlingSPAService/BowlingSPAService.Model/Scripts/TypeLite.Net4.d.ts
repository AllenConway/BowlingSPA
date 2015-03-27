

 


declare module BowlingSPAService.Model.EntityModels {
	interface Bowler {
		FullName: string;
		Id: number;
		FirstName: string;
		LastName: string;
		ModifiedDate: Date;
		Average: number;
		Handicap: number;
		Scores: BowlingSPAService.Model.EntityModels.Score[];
	}
	interface Score {
		Id: number;
		BowlerId: number;
		MatchId: number;
		TeamId: number;
		Pins: number;
		Handicap: number;
		ModifiedDate: Date;
		GameNumber: number;
		Bowler: BowlingSPAService.Model.EntityModels.Bowler;
		Match: BowlingSPAService.Model.EntityModels.Match;
		Team: BowlingSPAService.Model.EntityModels.Team;
	}
	interface Match {
		Id: number;
		Team1Id: number;
		Team2Id: number;
		MatchDate: Date;
		ModifiedDate: Date;
		Team: BowlingSPAService.Model.EntityModels.Team;
		Team1: BowlingSPAService.Model.EntityModels.Team;
		Scores: BowlingSPAService.Model.EntityModels.Score[];
	}
	interface Team {
		Id: number;
		Name: string;
		ModifiedDate: Date;
		LeagueId: number;
		Matches: BowlingSPAService.Model.EntityModels.Match[];
		Matches1: BowlingSPAService.Model.EntityModels.Match[];
		League: BowlingSPAService.Model.EntityModels.League;
		Scores: BowlingSPAService.Model.EntityModels.Score[];
	}
	interface League {
		Id: number;
		Name: string;
		ModifiedDate: Date;
		Teams: BowlingSPAService.Model.EntityModels.Team[];
	}
}
declare module BowlingSPAService.Model.DomainModels {
	interface BowlerStats {
		Average: number;
		BowlerName: string;
		HighGame: number;
		TeamName: string;
	}
}

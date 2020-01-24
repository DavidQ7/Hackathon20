import { Game } from './Game';

export interface Statistic {
    wins: number;
    losses: number;
    notFinished: number;
    games: Game[];
}

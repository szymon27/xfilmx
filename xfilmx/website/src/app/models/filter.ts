import { Country } from "./country";
import { Genre } from "./genre";

export class Filter {
    genres: Genre[];
    countries: Country[];
    filter: string;
    year: number;
  }
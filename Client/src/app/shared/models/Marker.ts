export interface Marker
{
    title: string;
    description: string;
    coordinations: Coordinations;
}

export interface Coordinations
{
    latitude: number;
    longitude: number;
}
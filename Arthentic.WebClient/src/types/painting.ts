export interface Painting {
  id: string;
  title: string;
  price: number;
  imageUrl?: string;
  artistName: string;
  categoryName?: string;
  dimensions?: string;
  medium?: string;
  isAvailable?: boolean;
}
export interface Painting {
  id: string;
  title: string;
  description: string;
  price: number;
  discountPrice?: number;
  width: number;
  height: number;
  medium: string;
  yearCreated: number;
  mainImageUrl: string;
  isAvailable: boolean;
  isFeatured: boolean;
  artistName?: string;
  categoryName?: string;
}
import { ArticleCategory } from './article-category';

export class Tutorial {
  id: number;
  title: string;
  url: string;
  row: number;
  content: string;
  picture: string;
  like: number;
  createdDate: Date;
  updateDate: Date;
  articleCategory: ArticleCategory;
  postCategory: string;
  comment: string;
  brainStormUser: string;
}

module Siege {
    export class AnimationResetStats {
        constructor(x: number, y: number, name: string) {
			this.x = x;
			this.y = y;
            this.name = name;
        }

        public x: number;
        public y: number;
        public name: string;
    }
}
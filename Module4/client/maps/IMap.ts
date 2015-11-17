module Siege {
	export interface IMap {
		createBackground(): void;
		createBattlefield(): void;
		createForeground(): void;
		updateBackground(): void;
		updateBattlefield(): void;
		updateForeground(): void;
	}
}
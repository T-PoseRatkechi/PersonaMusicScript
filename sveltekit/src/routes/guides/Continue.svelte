<script>
	import { base } from '$app/paths';
	import Link from '$lib/Link.svelte';
</script>

<b>Continue</b>
<ul>
	<li>
		<b><Link url="{base}/guides/boss-music">Custom Boss Music</Link></b>
	</li>
	<li>
		<b><Link url="{base}/guides/location-bgm">Location-based Battle Music</Link></b>
	</li>
	<li>
		<b
			><Link url="{base}/guides/battle-bgm"
				>Custom Battle BGM (Advantage, Disadvantage, Victory)</Link
			></b
		>
	</li>
	<li>
		For other features, such as <b>Floor BGM</b> and <b>Event BGM</b>, <Link url="{base}/docs"
			>read the docs.</Link
		>
	</li>
</ul>
